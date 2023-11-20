using Contracts.Shared;

namespace DotNetflixAPI.Hubs;

public interface IUserChatClient
{
    Task ReceiveAsync(MessageDto<string> message);
}