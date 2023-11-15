using Contracts.Shared;

namespace Services.Shared.SupportChatService;

public interface ISupportChatService
{
    IEnumerable<MessageDtoBase> GetHistory(string roomId, bool senderIsAdmin);
}
