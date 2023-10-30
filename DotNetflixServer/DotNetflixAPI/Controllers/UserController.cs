using Domain.Entities;
using DotNetflix.Application.Features.TwoFactorAuthorization.Commands.EnableTwoFactorAuth;
using DotNetflix.Application.Features.Users.Commands.SetUserData;
using DotNetflix.Application.Features.Users.Commands.SetUserMail;
using DotNetflix.Application.Features.Users.Commands.SetUserPassword;
using DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;
using DotNetflix.Application.Features.Users.Queries.GetUser;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using DotNetflix.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly UserManager<User> _userManager;

    public UserController(IMediator mediator, UserManager<User> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
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
        var user = await _userManager.GetUserAsync(User);
        var command = new SetUserPasswordCommand(user!, chPass.Password, UserManager<User>.ResetPasswordTokenPurpose, chPass.Token);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            Ok,
            BadRequest);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserMailAsync([FromBody] UserChangeMailDto chMail)
    {
        var user = await _userManager.GetUserAsync(User);
        var command = new SetUserMailCommand(user!, chMail.Email, UserManager<User>.GetChangeEmailTokenPurpose(chMail.Email), chMail.Token);
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

    [HttpPost("[action]")]
    public async Task<IActionResult> Enable2FAAsync([FromBody] EnableTwoFactorAuthDto dto)
    {
        var user = await _userManager.GetUserAsync(User);
        var command = new EnableTwoFactorAuthCommand(user!, UserManager<User>.ConfirmEmailTokenPurpose, dto.Token);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success: Ok,
            failure: BadRequest);
    }
}
