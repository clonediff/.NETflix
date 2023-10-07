using Contracts.Messages;

namespace DotNetflixAPI.Hubs;

public interface IClient
{
    Task ReceiveAsync(MessageDto message);
}