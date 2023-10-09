using Contracts.Shared;

namespace Services.Shared.SupportChatService;

public interface ISupportChatService
{
    IEnumerable<MessageDto> GetHistory(string roomId, bool senderIsAdmin);
}
