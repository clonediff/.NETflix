using System.Security.Claims;
using Contracts.Shared;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using DotNetflixAPI.Dto;
using DotNetflixAPI.Hubs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.Shared.SupportChatService;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/support-chat")]
[Authorize]
public class SupportChatController : Controller
{
    private readonly ISupportChatService _supportChatService;
    private readonly IHubContext<SupportChatHub, IClient> _hubContext;
    private readonly IMediator _mediator;
    
    private const string AdminName = "Администратор";
    
    public SupportChatController(ISupportChatService supportChatService, IMediator mediator, IHubContext<SupportChatHub, IClient> hubContext)
    {
        _supportChatService = supportChatService;
        _mediator = mediator;
        _hubContext = hubContext;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> History()
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        
        return Ok(_supportChatService.GetHistory(userId!, false));
    }
    
    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task UploadFile([FromForm] IEnumerable<IFormFile> files, [FromQuery] string roomId)
    {
        await using var stream = new MemoryStream();

        foreach (var file in files)
        {
            await SendFileAsync(stream, file, roomId);
        }
    }

    private async Task SendFileAsync(MemoryStream stream, IFormFile file, string roomId)
    {
        await file.CopyToAsync(stream);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var sendingDate = DateTime.Now;
        var username = User.FindFirstValue(ClaimTypes.Name) ?? AdminName;
        var image = new ImageDto($"data:{file.ContentType};base64,", stream.ToArray());

        var messageForSender = new MessageDto(image, username, sendingDate, true);
        var messageForReceiver = messageForSender with { BelongsToSender = false };
        
        if (userId is not null)
        {
            await _hubContext.Clients.User(userId).ReceiveAsync(messageForSender);
        }
        else
        {
            await _hubContext.Clients.GroupExcept(roomId, ConnectionStore.UserConnections[roomId]).ReceiveAsync(messageForSender);
        }
        
        await _hubContext.Clients.GroupExcept(roomId, ConnectionStore.UserConnections[userId ?? AdminName]).ReceiveAsync(messageForReceiver);
        
        stream.SetLength(0);
    }
}
