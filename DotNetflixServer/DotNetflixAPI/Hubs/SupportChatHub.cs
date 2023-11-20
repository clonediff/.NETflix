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

    public async Task SendMessageAsync(SendMessageDto<string> dto)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        var sendingDate = DateTime.Now;
        
        await SendAsync(groupName, sendingDate, dto.Message, dto, x => x);
    }

    public async Task SendFilesAsync(SendMessageDto<int[]> dto, string contentType)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        var sendingDate = DateTime.Now;
        var fileExtension = contentType.Split('/')[1];
        var content = $"file_{dto.RoomId}_{sendingDate:s}.{fileExtension}_{contentType}";
        var buffer = dto.Message.Select(x => (byte) x).ToArray();
        var image = new ImageDto($"data:{contentType};base64,", buffer);

        await SendAsync(groupName, sendingDate, content, dto, _ => image);
        
        await _bus.Publish(new FileMessage(buffer, $"{sendingDate:s}.{fileExtension}", groupName));
    }

    private async Task SendAsync<TInMessage, TOutMessage>(string groupName, DateTime sendingDate, string content,
        SendMessageDto<TInMessage> dto, 
        Func<TInMessage, TOutMessage> transformer)
    {
        var userName = Context.User?.Identity?.Name ?? AdminName;
        var messageForSender = new SupportChatMessageDto<TOutMessage>(groupName, transformer(dto.Message), userName, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        var (adminMessage, userMessage) = (messageForReceiver, messageForSender);
        if (Context.UserIdentifier is null)
            (adminMessage, userMessage) = (messageForSender, messageForReceiver);

        await Clients.Clients(AdminConnections).ReceiveAsync(adminMessage as dynamic);
        await Clients.User(groupName).ReceiveAsync(userMessage as dynamic);

        await _bus.Publish(new SupportChatMessage(
            Content: content,
            SendingDate: sendingDate,
            IsReadByAdmin: dto.RoomId is not null,
            IsFromAdmin: dto.RoomId is not null,
            RoomId: groupName));
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