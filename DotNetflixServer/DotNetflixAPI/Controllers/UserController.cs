using DotNetflix.Application.Features.Users.Commands.SetUserData;
using DotNetflix.Application.Features.Users.Commands.SetUserMail;
using DotNetflix.Application.Features.Users.Commands.SetUserPassword;
using DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;
using DotNetflix.Application.Features.Users.Queries.GetUser;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using DotNetflix.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<UserDto> GetUserAsync()
    {
        var query = new GetUserQuery(User);
        return await _mediator.Send(query);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUserSubscriptionsAsync()
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);

        if (userId is null)
            return BadRequest();

        var getAllUserSubscriptionsQuery = new GetAllUserSubscriptionsQuery(userId);
        var subscriptions = await _mediator.Send(getAllUserSubscriptionsQuery);
        return Ok(subscriptions);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserPasswordAsync([FromBody] UserChangePasswordDto chPass)
    {
        var command = new SetUserPasswordCommand(User, chPass.Password, chPass.Code);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            Ok,
            BadRequest);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserMailAsync([FromBody] UserChangeMailDto chMail)
    {
        var command = new SetUserMailCommand(User, chMail.Email, chMail.Code);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            Ok,
            BadRequest);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserDataAsync([FromBody] UserChangeOrdinaryDto chOrdinary)
    {
        var command = new SetUserDataCommand(User, chOrdinary.Birthdate, chOrdinary.UserName);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            Ok,
            BadRequest);
    }
}
