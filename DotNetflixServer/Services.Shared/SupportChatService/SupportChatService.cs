using Contracts.Shared;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Shared.SupportChatService;

public class SupportChatService : ISupportChatService
{
    private readonly DbContext _context;
    private const string AdminName = "Администратор";

    public SupportChatService(DbContext context)
    {
        _context = context;
    }


    public IEnumerable<MessageDto> GetHistory(string roomId, bool senderIsAdmin)
    {
        return _context.Set<Message>()
            .Include(x => x.User)
            .Where(x => x.UserId == roomId)
            .Select(x => new MessageDto(x.Content, x.IsFromAdmin ? AdminName : x.User.UserName!, x.SendingDate,
                senderIsAdmin == x.IsFromAdmin));
    }
}
