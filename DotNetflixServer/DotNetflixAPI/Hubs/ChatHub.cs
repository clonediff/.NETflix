using System.Collections.Concurrent;
using Contracts.Messages;
using Microsoft.AspNetCore.SignalR;
using Services.Abstractions;

namespace DotNetflixAPI.Hubs;

public class ChatHub : Hub<IClient>
{
    private static readonly ConcurrentDictionary<string, List<string>> _userConnections = new();
    private readonly IChatStorage _chatStorage;

    public ChatHub(IChatStorage chatStorage)
    {
        _chatStorage = chatStorage;
    }

    public async Task SendAsync(string message)
    {
        var userName = Context.User!.Identity!.Name;
        var date = DateTime.Now;
        
        _chatStorage.PutMessage(new UserMessageDto(message, userName!, date, Context.UserIdentifier!));

        var userMessage = new MessageDto(message, userName!, date, true);

        await Clients.User(Context.UserIdentifier!).ReceiveAsync(userMessage);
        await Clients.AllExcept(_userConnections[Context.UserIdentifier!]).ReceiveAsync(userMessage with { BelongsToSender = false});
    }

    public override Task OnConnectedAsync()
    {
        _userConnections.AddOrUpdate(
            key: Context.UserIdentifier!,
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
}