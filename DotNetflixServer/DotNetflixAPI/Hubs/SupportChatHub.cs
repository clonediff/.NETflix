using System.Collections.Immutable;
using Contracts.Shared;
using DotNetflixAPI.Dto;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class SupportChatHub : Hub<IClient>
{
    private static readonly List<string> AdminConnections = new();
    private const string AdminName = "Администратор";

    private readonly IBus _bus;

    public SupportChatHub(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendAsync(SendMessageDto dto)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        
        var userName = Context.User?.Identity?.Name ?? AdminName;
        var sendingDate = DateTime.Now;
        var messageForSender = new MessageDto(groupName, dto.Message, userName, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        if (Context.UserIdentifier is null)
        {
            await Clients.Clients(AdminConnections).ReceiveAsync(messageForSender);
            await Clients.User(groupName).ReceiveAsync(messageForReceiver);
        }
        else
        {
            await Clients.User(groupName).ReceiveAsync(messageForSender);
            await Clients.Clients(AdminConnections).ReceiveAsync(messageForReceiver);
        }

        await _bus.Publish(new SupportChatMessage(
            Content: dto.Message,
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