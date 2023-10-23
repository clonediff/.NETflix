using Contracts;
using Contracts.ChangeUserData;
using Domain.Entities;
using Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Shared.TwoFactorAuthCodeService;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ITwoFactorAuthCodeService _twoFactorAuthCodeService;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;

    public UserController(ITwoFactorAuthCodeService twoFactorAuthCodeService, UserManager<User> userManager, IUserService userService)
    {
        _twoFactorAuthCodeService = twoFactorAuthCodeService;
        _userManager = userManager;
        _userService = userService;
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
        var userId = await _userService.GetUserIdAsync(User);

        if (userId is null)
            return BadRequest();

        var subscriptions = _userService.GetAllUserSubscriptions(userId);
        return Ok(subscriptions);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserPassword([FromBody] UserChangePasswordDto chPass)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (!_twoFactorAuthCodeService.CheckCode(user!.Email!, chPass.Code))
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
        if (!_twoFactorAuthCodeService.CheckCode(user!.Email!, chMail.Code))
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