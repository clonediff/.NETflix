using Contracts.Messages;

namespace Services.Abstractions;

public interface IChatStorage
{
    void PutMessage(UserMessageDto message);
    List<UserMessageDto> GetAllMessages();
}