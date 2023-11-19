using Contracts.Shared;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Services.Shared.SupportChatService;

public class SupportChatService : ISupportChatService
{
    private readonly ApplicationDBContext _context;
    private const string AdminName = "Администратор";

    public SupportChatService(ApplicationDBContext context)
    {
        _context = context;
    }

    public IEnumerable<MessageDto> GetHistory(string roomId, bool senderIsAdmin)
    {
        return _context.Messages
            .Include(x => x.User)
            .Where(x => x.UserId == roomId)
            .Select(x => new MessageDto(roomId, x.Content, x.IsFromAdmin ? AdminName : x.User.UserName!, x.SendingDate,
                senderIsAdmin == x.IsFromAdmin));
    }
}
