using System.Collections.Concurrent;
using Contracts.Shared;
using DotNetflixAPI.Dto;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class SupportChatHub : Hub<IClient>
{
    private static readonly ConcurrentDictionary<string, List<string>> UserConnections = new();
    private const string AdminName = "Администратор";

    private readonly IBus _bus;

    public SupportChatHub(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendMessageAsync(SendMessageDto<string> dto)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        await SendAsync(groupName, dto, x => x);
    }

    public async Task SendFilesAsync(SendMessageDto<IEnumerable<int[]>> dto)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        
        foreach (var file in dto.Message)
        {
            var image = new ImageDto("data:img/png;base64,", file.Select(x => (byte) x).ToArray());
        
            await SendAsync(groupName, dto, _ => image);
        }
    }

    private async Task SendAsync<TInMessage, TOutMessage>(string groupName, SendMessageDto<TInMessage> dto, Func<TInMessage, TOutMessage> transformer)
    {
        var sendingDate = DateTime.Now;
        var userName = Context.User?.Identity?.Name ?? AdminName;
        var messageForSender = MessageDtoFactory.Create(transformer(dto.Message), userName, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        if (Context.UserIdentifier is null)
        {
            await Clients.GroupExcept(groupName, UserConnections[groupName]).ReceiveAsync(messageForSender);
        }
        else
        {
            await Clients.User(Context.UserIdentifier!).ReceiveAsync(messageForSender);
        }
        
        await Clients.GroupExcept(groupName, UserConnections[Context.UserIdentifier ?? AdminName]).ReceiveAsync(messageForReceiver);
        
        await _bus.Publish(new SupportChatMessage(
            Content: dto.Message as string ?? $"file_{dto.RoomId}_{sendingDate}",
            SendingDate: sendingDate,
            IsReadByAdmin: dto.RoomId is not null,
            IsFromAdmin: dto.RoomId is not null,
            RoomId: groupName));

        await Clients.Caller.ReceiveAsync(messageForSender);
    }

    public override Task OnConnectedAsync()
    {
        UserConnections.AddOrUpdate(
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
        UserConnections[Context.UserIdentifier ?? AdminName].Remove(Context.ConnectionId);

        return Task.CompletedTask;
    }
}