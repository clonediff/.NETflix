using DtoLibrary;

namespace Services.ChatStorage;

public class ChatStorage : IChatStorage
{
    private readonly List<UserMessageDto> _messages = new();

    public void PutMessage(UserMessageDto message)
    {
        _messages.Add(message);
    }

    public List<UserMessageDto> GetAllMessages()
    {
        return _messages;
    }
}