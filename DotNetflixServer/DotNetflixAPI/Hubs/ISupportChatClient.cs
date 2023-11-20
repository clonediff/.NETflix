using Contracts.Shared;

namespace DotNetflixAPI.Hubs;

public interface ISupportChatClient
{
    Task ReceiveAsync(dynamic message);
}