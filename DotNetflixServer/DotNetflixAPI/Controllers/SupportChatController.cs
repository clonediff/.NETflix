using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Shared.SupportChatService;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/support-chat")]
[Authorize]
public class SupportChatController : Controller
{
    private readonly ISupportChatService _supportChatService;
    
    public SupportChatController(ISupportChatService supportChatService)
    {
        _supportChatService = supportChatService;
    }

    [HttpGet("[action]")]
    public IActionResult History([FromQuery]string roomId)
    {
        return Ok(_supportChatService.GetHistory(roomId, true));
    }
}
