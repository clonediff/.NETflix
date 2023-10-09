using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Messages;
using DataAccess;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/support-chat")]
[Authorize(Policy = "Admin")]
public class SupportChatController : Controller
{
    private readonly ApplicationDBContext _context;
    
    private const string AdminName = "Администратор";

    public SupportChatController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet("[action]")]
    public IActionResult Preview(int page)
    {
        int pageSize = 25;
        var messages = _context.Messages
            .Include(x => x.User)
            .GroupBy(x => x.User)
            .Select(x =>
                new
                {
                    RoomId = x.Key.Id,
                    LatestMessage = x.OrderByDescending(y => y.SendingDate).First(),
                    UnreadMessages = x.Count(y => !y.IsRead)
                })
            .Paginate(page, pageSize)
            .AsEnumerable()
            .Select(x =>
                new PreviewMessageDto(x.RoomId, x.LatestMessage.IsFromAdmin ? AdminName : x.LatestMessage.User.UserName!, x.LatestMessage.Content,
                    x.UnreadMessages))
            .ToList();
        return Ok(new PaginationDataDto<PreviewMessageDto>(messages, messages.Count));
    }
}