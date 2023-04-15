using DataAccess.Entities.Forms.LoginForm;
using DataAccess.Entities.Forms.RegisterForm;
using DataAccess.Entities.IdentityLogic;
using DtoLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Mappers;
using Services.TwoFAService;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ITwoFAService _twoFAService;
    readonly UserManager<User> _userManager;
    public UserController(UserManager<User> userManager, ITwoFAService twoFAService)
    {
        _userManager = userManager;
        _twoFAService = twoFAService;
    }

    [HttpGet("[action]")]
    public async Task<UserDto> GetUserAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        return user?.ToUserDto()!;
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserPassword([FromBody] UserChangePasswordDto chPass )
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (!_twoFAService.CheckCode(user, chPass.Code))
			return BadRequest("Код не совпадает или устарел");

        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, chPass.Password);
        var changeRes = await _userManager.UpdateAsync(user);
        return changeRes.Succeeded? Ok("Пароль изменён"): BadRequest(changeRes.Errors);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserMail([FromBody] UserChangeMailDto chMail)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (!_twoFAService.CheckCode(user, chMail.Code))
			return BadRequest("Код не совпадает или устарел");

        var changeRes = await _userManager.SetEmailAsync(user, chMail.Email);
        return changeRes.Succeeded? Ok("Почта изменена"): BadRequest(changeRes.Errors);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> SetUserData([FromBody] UserChangeOrdinaryDto chOrdinary)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        user.UserName = chOrdinary.UserName;
        user.Birthday = chOrdinary.Birthdate;
        var changeRes = await _userManager.UpdateAsync(user);
        return changeRes.Succeeded? Ok("Данные изменены"): BadRequest(changeRes.Errors);
    }
}
