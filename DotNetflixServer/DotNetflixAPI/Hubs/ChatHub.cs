using System.Collections.Concurrent;
using Contracts.Shared;
using DotNetflix.Application.Features.UserChat.Commands.PutMessage;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class ChatHub : Hub<IUserChatClient>
{
    private static readonly ConcurrentDictionary<string, List<string>> UserConnections = new();
    private readonly IMediator _mediator;

    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task SendAsync(string message)
    {
        var userName = Context.User!.Identity!.Name;
        var date = DateTime.Now;

        var command = new PutMessageCommand(message, date, Context.UserIdentifier!);
        await _mediator.Send(command);

        var messageForSender = new MessageDto<string>(message, userName!, date, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };

        await Clients.User(Context.UserIdentifier!).ReceiveAsync(messageForSender);
        await Clients.AllExcept(UserConnections[Context.UserIdentifier!]).ReceiveAsync(messageForReceiver);
    }

    public override Task OnConnectedAsync()
    {
        UserConnections.AddOrUpdate(
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