using DtoLibrary;

namespace BackendAPI.Hub;

public interface IClient
{
    Task ReceiveAsync(MessageDto message);
}