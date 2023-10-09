using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Shared.SupportChatService;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/support-chat")]
[Authorize]
public class SupportChatController : Controller
{
    private readonly ISupportChatService _supportChatService;
    private readonly IUserService _userService;
    
    public SupportChatController(ISupportChatService supportChatService, IUserService userService)
    {
        _supportChatService = supportChatService;
        _userService = userService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> History()
    {
        var userId = await _userService.GetUserIdAsync(HttpContext.User);
        
        return Ok(_supportChatService.GetHistory(userId!, false));
    }
}
