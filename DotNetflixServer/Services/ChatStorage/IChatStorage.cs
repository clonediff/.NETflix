using DtoLibrary;

namespace Services.ChatStorage;

public interface IChatStorage
{
    void PutMessage(UserMessageDto message);
    List<UserMessageDto> GetAllMessages();
}