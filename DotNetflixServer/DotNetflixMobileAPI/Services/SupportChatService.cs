using System.Collections.Concurrent;
using System.Text.Json;
using Contracts.Shared;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MassTransit;
using Services.Shared.SupportChatService;
using static DotNetflixMobileAPI.Services.SupportChatServiceUtils;

namespace DotNetflixMobileAPI.Services;

public class SupportChatService : DotNetflixMobileAPI.SupportChatService.SupportChatServiceBase
{
    private static readonly ConcurrentDictionary<string, List<(string userName, IServerStreamWriter<MessageResponse> stream)>> _rooms = [];
    private const string AdminName = "Администратор";
    private readonly ISupportChatService _supportChatService;
    private readonly IBus _bus;

    public SupportChatService(ISupportChatService supportChatService, IBus bus)
    {
        _supportChatService = supportChatService;
        _bus = bus;
    }

    public override async Task<Empty> SendTextMessage(TextMessageRequest request, ServerCallContext context)
    {
        var roomId = GetUserId(context) ?? request.RoomId;
        var sendingDate = DateTime.UtcNow;

        await SendAsync(roomId, sendingDate, context, request.Content, MessageType.Text, new Any 
        { 
            Value = ByteString.CopyFromUtf8(request.Content)
        });

        return new Empty();
    }

    public override async Task<Empty> SendFileMessage(FileMessageRequest request, ServerCallContext context)
    {
        var roomId = GetUserId(context) ?? request.RoomId;
        var sendingDate = DateTime.UtcNow;
        var fileExtension = request.ContentType.Split('/')[1];
        var contentToPersist = $"file_{roomId}_{sendingDate:s}.{fileExtension}_{request.ContentType}";
        var buffer = request.Content.ToByteArray();
        var image = new ImageDto($"data:{request.ContentType};base64,", buffer);

        await SendAsync(roomId, sendingDate, context, contentToPersist, MessageType.File, new Any
        {
            Value = ByteString.CopyFromUtf8(JsonSerializer.Serialize(image))
        });

        await _bus.Publish(new FileMessage(buffer, $"{sendingDate:s}.{fileExtension}", roomId));

        return new Empty();
    }

    private async Task SendAsync(string roomId, DateTime sendingDate, ServerCallContext context, string contentToPersist, MessageType contentType, Any content)
    {
        var senderName = GetUserName(context) ?? AdminName;

        foreach (var (userName, stream) in _rooms[roomId])
        {
            await stream.WriteAsync(new MessageResponse
            {
                RoomId = roomId,
                Content = content,
                MessageType = contentType,
                SenderName = senderName,
                SendingDate = Timestamp.FromDateTime(sendingDate),
                BelongsToSender = userName == senderName
            });
        }

        await _bus.Publish(new SupportChatMessage(
            Content: contentToPersist,
            SendingDate: sendingDate,
            IsReadByAdmin: senderName == AdminName,
            IsFromAdmin: senderName == AdminName,
            RoomId: roomId
        ));
    }

    public override Task ReceiveMessage(ReceiveRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        var userName = GetUserName(context) ?? AdminName;

        _rooms.AddOrUpdate(
            key: request.RoomId,
            addValueFactory: x => [(userName, responseStream)],
            updateValueFactory: (_, room) =>
            {
                room.Add((userName, responseStream));
                return room;
            }
        );

        while (!context.CancellationToken.IsCancellationRequested) {}

        _rooms[request.RoomId].Remove((userName, responseStream));

        return Task.CompletedTask;
    }

    public override async Task History(HistoryRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        var history = await _supportChatService.GetHistoryAsync(request.RoomId, false);

        foreach (var message in history)
        {
            await responseStream.WriteAsync(new MessageResponse
            {
                RoomId = request.RoomId,
                Content = new Any
                {
                    Value = message.MessageType == SupportChatMessageType.Text
                        ? ByteString.CopyFromUtf8(message.Message)
                        : ByteString.CopyFromUtf8(JsonSerializer.Serialize(message.Content))
                },
                MessageType = ToMessageType(message.MessageType),
                SenderName = message.SenderName,
                SendingDate = Timestamp.FromDateTime(message.SendingDate.ToUniversalTime()),
                BelongsToSender = message.BelongsToSender
            });
        }
    }

    public override async Task<Empty> ForwardMessage(MessageResponse request, ServerCallContext context)
    {
        foreach (var (_, stream) in _rooms[request.RoomId].Where(x => x.userName == request.SenderName))
        {
            await stream.WriteAsync(request);
        }

        return new Empty();
    }
}