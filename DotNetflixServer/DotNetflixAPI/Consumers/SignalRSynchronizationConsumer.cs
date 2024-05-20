using Contracts.Shared;
using DotNetflixAPI.Hubs;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace DotNetflixAPI.Consumers;

public class SignalRSynchronizationConsumer : 
    IConsumer<SignalRSynchronizationMessage<string>>,
    IConsumer<SignalRSynchronizationMessage<ImageDto>>
{
    private readonly IHubContext<SupportChatHub, ISupportChatClient> _hubContext;

    public SignalRSynchronizationConsumer(IHubContext<SupportChatHub, ISupportChatClient> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task Consume(ConsumeContext<SignalRSynchronizationMessage<string>> context)
    {
        await Consume(context.Message);
    }

    public async Task Consume(ConsumeContext<SignalRSynchronizationMessage<ImageDto>> context)
    {
        await Consume(context.Message);
    }

    private async Task Consume<TContent>(SignalRSynchronizationMessage<TContent> message)
    {
        await _hubContext.Clients.User(message.Dto.RoomId!).ReceiveAsync(message.Dto);
    }
}