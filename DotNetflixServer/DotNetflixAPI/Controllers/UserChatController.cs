using System.Security.Claims;
using Contracts.Shared;
using DotNetflix.Application.Features.UserChat.Mapping;
using DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<MessageDto<string>>> GetAll()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var query = new GetAllMessagesQuery();
        var messages = await _mediator.Send(query);

        return messages.Select(m => m.ToMessageDto(userId!));
    }
}