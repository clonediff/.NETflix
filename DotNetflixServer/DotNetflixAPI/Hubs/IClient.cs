using Contracts.Shared;

namespace DotNetflixAPI.Hubs;

public interface IClient
{
    Task ReceiveAsync(MessageDtoBase message);
}