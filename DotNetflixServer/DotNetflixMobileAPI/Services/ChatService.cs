using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace DotNetflixMobileAPI.Services;

public class ChatService : DotNetflixMobileAPI.ChatService.ChatServiceBase
{
    private static readonly ConcurrentDictionary<string, List<(string name, IServerStreamWriter<MessageResponse> stream)>> _rooms = [];
    private const string AdminName = "Администратор";

    public override Task<Empty> SendTextMessage(TextMessageRequest request, ServerCallContext context)
    {
        return SendMessageAsync(request.RoomId, context, ContentType.Text, new Any 
        { 
            Value = ByteString.CopyFromUtf8(request.Content)
        });
    }

    public override Task<Empty> SendFileMessage(FileMessageRequest request, ServerCallContext context)
    {
        return SendMessageAsync(request.RoomId, context, ContentType.File, new Any
        {
            Value = request.Content
        });
    }

    private static Task<Empty> SendMessageAsync(string roomId, ServerCallContext context, ContentType contentType, Any content)
    {
        var userName = context.GetHttpContext().User?.Identity?.Name ?? AdminName;
        var sendingDate = DateTime.UtcNow;

        _rooms[roomId].ForEach(async x =>
        {
            var (name, stream) = x;
            await stream.WriteAsync(new MessageResponse
            {
                RoomId = roomId,
                Content = content,
                ContentType = contentType,
                SenderName = userName,
                SendingDate = Timestamp.FromDateTime(sendingDate),
                BelongsToSender = name == userName
            });
        });

        return Task.FromResult(new Empty());
    }

    public override Task ReceiveMessage(ReceiveRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        var userName = context.GetHttpContext().User?.Identity?.Name ?? AdminName;

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
}