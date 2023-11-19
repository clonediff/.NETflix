using Contracts.Shared;

namespace DotNetflixAPI.Hubs;

public interface ISupportChatClient
{
    Task ReceiveAsync(MessageDto<dynamic> message);
}