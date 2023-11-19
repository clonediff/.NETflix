using Contracts.Shared;

namespace Services.Shared.SupportChatService;

public interface ISupportChatService
{
    IEnumerable<SupportChatMessageDto> GetHistory(string roomId, bool senderIsAdmin);
}
