using DotNetflix.Application.Features.User.Queries.GetUserId;
using MediatR;
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
    private readonly IMediator _mediator;
    
    public SupportChatController(ISupportChatService supportChatService, IMediator mediator)
    {
        _supportChatService = supportChatService;
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> History()
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        
        return Ok(_supportChatService.GetHistory(userId!, false));
    }
}
