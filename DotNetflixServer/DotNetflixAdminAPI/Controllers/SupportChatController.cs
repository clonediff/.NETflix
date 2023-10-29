using DotNetflix.Admin.Application.Features.AdminSupportChat.Commands.MarkAsRead;
using DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Shared.SupportChatService;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/support-chat")]
[Authorize(Policy = "Admin")]
public class SupportChatController : Controller
{
    private readonly ISupportChatService _supportChatService;
    private readonly IMediator _mediator;
    
    public SupportChatController(ISupportChatService supportChatService, IMediator mediator)
    {
        _supportChatService = supportChatService;
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Preview([FromQuery] int page, [FromQuery] int size)
    {
        var query = new GetPreviewsQuery(page, size);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult History([FromQuery] string roomId)
    {
        return Ok(_supportChatService.GetHistory(roomId, true));
    }

    [HttpPatch("[action]")]
    public async Task<IActionResult> MarkAsRead([FromQuery] string roomId)
    {
        var command = new MarkAsReadCommand(roomId);
        await _mediator.Send(command);
        return Ok();
    }
}