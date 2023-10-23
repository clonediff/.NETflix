using Contracts;
using Contracts.ChangeUserData;
using Domain.Entities;
using DotNetflix.Application.Features.User.Queries.GetAllUserSubscriptions;
using DotNetflix.Application.Features.User.Queries.GetUserId;
using Mappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ITwoFAService _twoFAService;
    private readonly UserManager<User> _userManager;
    private readonly IMediator _mediator;

    public UserController(UserManager<User> userManager, ITwoFAService twoFAService, IMediator mediator)
    {
        _userManager = userManager;
        _twoFAService = twoFAService;
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<UserDto> GetUserAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.ToUserDto()!;
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
    public async Task<IActionResult> SetUserPassword([FromBody] UserChangePasswordDto chPass)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (!_twoFAService.CheckCode(user!.Email!, chPass.Code))
        {
            return BadRequest("Код не совпадает или устарел");
        }

        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, chPass.Password);
        var changeRes = await _userManager.UpdateAsync(user);
        return changeRes.Succeeded ? Ok("Пароль изменён") : BadRequest(changeRes.Errors);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserMail([FromBody] UserChangeMailDto chMail)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (!_twoFAService.CheckCode(user!.Email!, chMail.Code))
        {
            return BadRequest("Код не совпадает или устарел");
        }

        var changeRes = await _userManager.SetEmailAsync(user, chMail.Email);
        return changeRes.Succeeded ? Ok("Почта изменена") : BadRequest(changeRes.Errors);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserData([FromBody] UserChangeOrdinaryDto chOrdinary)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        user!.UserName = chOrdinary.UserName;
        user.Birthday = chOrdinary.Birthdate;
        var changeRes = await _userManager.UpdateAsync(user);
        return changeRes.Succeeded ? Ok("Данные изменены") : BadRequest(changeRes.Errors);
    }
}