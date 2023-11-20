namespace Services.Shared.SupportChatService;

public interface ISupportChatService
{
    Task<IEnumerable<dynamic>> GetHistoryAsync(string roomId, bool senderIsAdmin);
}
