using System.Text.Json;
using Contracts.Shared;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using MassTransit;
using static DotNetflixMobileAPI.Services.SupportChatServiceUtils;

namespace DotNetflixMobileAPI.Consumers;

public class GrpcSynchronizationConsumer : 
    IConsumer<GrpcSynchronizationMessage<string>>,
    IConsumer<GrpcSynchronizationMessage<ImageDto>>
{
    public async Task Consume(ConsumeContext<GrpcSynchronizationMessage<string>> context)
    {
        await Consume(context.Message);
    }

    public async Task Consume(ConsumeContext<GrpcSynchronizationMessage<ImageDto>> context)
    {
        await Consume(context.Message);
    }

    private static async Task Consume<TContent>(GrpcSynchronizationMessage<TContent> message)
    {
        var roomExists = Services.SupportChatService.Rooms.TryGetValue(message.Dto.RoomId, out var namedStreams);

        if (!roomExists || namedStreams is null) return;

        foreach (var (_, stream) in namedStreams.Where(x => x.userName == message.Dto.SenderName))
        {
            await stream.WriteAsync(new MessageResponse
            {
                RoomId = message.Dto.RoomId,
                Content = new Any
                {
                    Value = message.Dto.MessageType == SupportChatMessageType.Text
                        ? ByteString.CopyFromUtf8(message.Dto.Content as string)
                        : ByteString.CopyFromUtf8(JsonSerializer.Serialize(message.Dto.Content))
                },
                MessageType = ToMessageType(message.Dto.MessageType),
                SenderName = message.Dto.SenderName,
                SendingDate = Timestamp.FromDateTime(message.Dto.SendingDate.ToUniversalTime()),
                BelongsToSender = message.Dto.BelongsToSender
            });
        }
    }
}
