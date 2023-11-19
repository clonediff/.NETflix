using System.Collections.Concurrent;
using Contracts.Shared;
using DotNetflix.Application.Features.UserChat.Commands.PutMessage;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Hubs;

public class ChatHub : Hub<IClient>
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

        var userMessage = new MessageDto("", message, userName!, date, true);

        await Clients.User(Context.UserIdentifier!).ReceiveAsync(userMessage);
        await Clients.AllExcept(UserConnections[Context.UserIdentifier!]).ReceiveAsync(userMessage with { BelongsToSender = false});
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