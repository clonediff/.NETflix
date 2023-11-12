using Contracts.Shared;
using DotNetflixAPI.Dto;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class SupportChatHub : Hub<IClient>
{
    private const string AdminName = "Администратор";

    private readonly IBus _bus;

    public SupportChatHub(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendAsync(SendMessageDto dto)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        
        var userName = Context.User?.Identity?.Name ?? AdminName;
        var sendingDate = DateTime.Now;
        var messageForSender = new MessageDto(dto.Message, userName, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        if (Context.UserIdentifier is null)
        {
            await Clients.GroupExcept(groupName, ConnectionStore.UserConnections[groupName]).ReceiveAsync(messageForSender);
        }
        else
        {
            await Clients.User(Context.UserIdentifier!).ReceiveAsync(messageForSender);
        }
        
        await Clients.GroupExcept(groupName, ConnectionStore.UserConnections[Context.UserIdentifier ?? AdminName]).ReceiveAsync(messageForReceiver);

        await _bus.Publish(new SupportChatMessage(
            Content: dto.Message,
            SendingDate: sendingDate,
            IsReadByAdmin: dto.RoomId is not null,
            IsFromAdmin: dto.RoomId is not null,
            RoomId: groupName));
    }

    public override Task OnConnectedAsync()
    {
        ConnectionStore.UserConnections.AddOrUpdate(
            key: Context.UserIdentifier ?? AdminName,
            addValue: new List<string>
            {
                Context.ConnectionId
            },
            updateValueFactory: (_, value) =>
            {
                value.Add(Context.ConnectionId);
                return value;
            });
        
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        ConnectionStore.UserConnections[Context.UserIdentifier ?? AdminName].Remove(Context.ConnectionId);

        return Task.CompletedTask;
    }
}