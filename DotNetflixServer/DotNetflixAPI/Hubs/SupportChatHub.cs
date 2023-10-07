using System.Collections.Concurrent;
using Contracts.Messages;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class SupportChatHub : Hub<IClient>
{
    private static readonly ConcurrentDictionary<string, List<string>> _userConnections = new();
    private const string _adminName = "Администратор";
    
    public async Task SendAsync(SendMessageDto dto)
    {
        var groupName = dto.RoomId ?? Context.UserIdentifier!;
        
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        
        var userName = Context.User?.Identity?.Name ?? _adminName;
        var sendingDate = DateTime.Now;
        var messageForSender = new MessageDto(dto.Message, userName, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        if (Context.UserIdentifier is null)
        {
            await Clients.GroupExcept(groupName, _userConnections[groupName]).ReceiveAsync(messageForSender);
        }
        else
        {
            await Clients.User(Context.UserIdentifier!).ReceiveAsync(messageForSender);
        }
        
        await Clients.GroupExcept(groupName, _userConnections[Context.UserIdentifier ?? _adminName]).ReceiveAsync(messageForReceiver);
    }

    public override Task OnConnectedAsync()
    {
        _userConnections.AddOrUpdate(
            key: Context.UserIdentifier ?? _adminName,
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
        _userConnections[Context.UserIdentifier ?? _adminName].Remove(Context.ConnectionId);

        return Task.CompletedTask;
    }
}