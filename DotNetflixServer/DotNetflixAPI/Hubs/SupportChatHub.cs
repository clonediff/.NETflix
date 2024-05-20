using Contracts.Shared;
using DotNetflixAPI.Dto;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class SupportChatHub : Hub<ISupportChatClient>
{
    private static readonly List<string> AdminConnections = new();
    private const string AdminName = "Администратор";

    private readonly IBus _bus;

    public SupportChatHub(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendMessageAsync(SendMessageDto<string> dto, string uniqueKey)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        var sendingDate = DateTime.UtcNow;
        
        await SendAsync(groupName, sendingDate, dto.Message, uniqueKey, dto, x => x, SupportChatMessageType.Text);
    }

    public async Task SendFilesAsync(SendMessageDto<int[]> dto, string contentType, string uniqueKey)
    {
        var roomId = dto.RoomId ?? Context.UserIdentifier!;
        var sendingDate = DateTime.UtcNow;
        var fileExtension = contentType.Split('/')[1];
        var fileName = string.IsNullOrEmpty(uniqueKey) ? sendingDate.ToString("s") : uniqueKey;
        var content = $"file_{roomId}_{fileName}.{fileExtension}_{contentType}";
        var buffer = dto.Message.Select(x => (byte) x).ToArray();
        var image = new ImageDto($"data:{contentType};base64,", buffer);

        await SendAsync(roomId, sendingDate, content, uniqueKey, dto, _ => image, SupportChatMessageType.File);
        
        await _bus.Publish(new FileMessage(buffer, $"{fileName}.{fileExtension}", roomId));
    }

    private async Task SendAsync<TInMessage, TOutMessage>(string roomId, DateTime sendingDate, string contentToPersist,
        string uniqueKey,
        SendMessageDto<TInMessage> dto, 
        Func<TInMessage, TOutMessage> transformer,
        SupportChatMessageType messageType)
    {
        var senderName = Context.User?.Identity?.Name ?? AdminName;
        var messageForSender = new SupportChatMessageDto<TOutMessage>(roomId, messageType, transformer(dto.Message), senderName, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        var (adminMessage, userMessage) = (messageForReceiver, messageForSender);
        if (Context.UserIdentifier is null)
            (adminMessage, userMessage) = (messageForSender, messageForReceiver);

        await Clients.Clients(AdminConnections).ReceiveAsync(adminMessage);
        await Clients.User(roomId).ReceiveAsync(userMessage);

        await _bus.Publish(new SupportChatMessage(
            Content: contentToPersist,
            SendingDate: sendingDate,
            IsReadByAdmin: dto.RoomId is not null,
            IsFromAdmin: dto.RoomId is not null,
            RoomId: roomId,
            UniqueKey: uniqueKey
        ));

        if (senderName != AdminName)
        {
            await _bus.Publish(new GrpcSynchronizationMessage<TOutMessage>(messageForSender));
        }
    }

    public override Task OnConnectedAsync()
    {
        if (Context.UserIdentifier is null)
            AdminConnections.Add(Context.ConnectionId);
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        AdminConnections.Remove(Context.ConnectionId);

        return Task.CompletedTask;
    }
}