using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;
using Services.Shared.SupportChatService;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/support-chat")]
[Authorize(Policy = "Admin")]
public class SupportChatController : Controller
{
    private readonly IAdminSupportChatService _adminSupportChatService;
    private readonly ISupportChatService _supportChatService;
    
    public SupportChatController(IAdminSupportChatService adminSupportChatService, ISupportChatService supportChatService)
    {
        _adminSupportChatService = adminSupportChatService;
        _supportChatService = supportChatService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Preview([FromQuery] int page, [FromQuery] int size)
    {
        return Ok(await _adminSupportChatService.GetPreviewsAsync(page, size));
    }

    [HttpGet("[action]")]
    public IActionResult History([FromQuery] string roomId)
    {
        return Ok(_supportChatService.GetHistory(roomId, true));
    }

    [HttpPatch("[action]")]
    public async Task<IActionResult> MarkAsRead([FromQuery] string roomId)
    {
        await _adminSupportChatService.MarkAsReadAsync(roomId);
        return Ok();
    }
}