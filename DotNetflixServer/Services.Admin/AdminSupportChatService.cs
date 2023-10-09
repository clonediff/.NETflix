using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Messages;
using DataAccess;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Services.Admin.Abstractions;

namespace Services.Admin;

public class AdminSupportChatService : IAdminSupportChatService
{
    private readonly ApplicationDBContext _context;
    
    private const string AdminName = "Администратор";

    public AdminSupportChatService(ApplicationDBContext context)
    {
        _context = context;
    }
    
    public async Task<PaginationDataDto<PreviewMessageDto>> GetPreviewsAsync(int page, int pageSize)
    {
        var rooms = _context.Messages
            .Include(x => x.User)
            .GroupBy(x => x.User)
            .Select(x =>
                new
                {
                    RoomId = x.Key.Id,
                    LatestMessage = x.OrderByDescending(y => y.SendingDate).First(),
                    UnreadMessages = x.Count(y => !y.IsRead)
                });
        
        var totalRoomsCount = await rooms.CountAsync(); 
        
        var resultRooms = rooms 
            .Paginate(page, pageSize)
            .AsEnumerable()
            .Select(x =>
                new PreviewMessageDto(x.RoomId, x.LatestMessage.IsFromAdmin ? AdminName : x.LatestMessage.User.UserName!, x.LatestMessage.Content,
                    x.UnreadMessages))
            .ToList();
        return new PaginationDataDto<PreviewMessageDto>(resultRooms, totalRoomsCount);
    }

    public async Task MarkAsReadAsync(string roomId)
    {
        await _context.Messages
            .Where(x => x.UserId == roomId)
            .ExecuteUpdateAsync(x => x.SetProperty(m => m.IsRead, true));
    }
}
