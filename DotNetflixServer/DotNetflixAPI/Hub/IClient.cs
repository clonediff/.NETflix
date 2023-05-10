using Contracts;
using Contracts.Messages;

namespace DotNetflixAPI.Hub;

public interface IClient
{
    Task ReceiveAsync(MessageDto message);
}