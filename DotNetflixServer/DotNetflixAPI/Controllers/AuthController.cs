using Contracts.Forms;
using DotNetflix.Application.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginForm form)
    {
        //тут нужно будет сделать функционал с запоминанием пользователя(через Services.AddAuthentication().AddCookie())
        if (!ModelState.IsValid) return BadRequest("Проверьте введённые вами данные на корректность");
        var loginResult = await _authService.Login(form);
        if (loginResult.IsSuccess)
        {
            return Ok("Вы успешно вошли в аккаунт!");
        }
        return BadRequest(loginResult.ErrorMessage);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Logout()
    { 
        await _authService.Logout();
        return Ok("Вы успешно вышли из аккаунта");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody]RegisterForm form)
    {
        //сделать функционал с отправкой сообщения пользователю, если человек пытается зарегистрироваться по его майлу
        if (!ModelState.IsValid) return BadRequest("Проверьте введённые вами данные на корректность");
        var registerResult = await _authService.Register(form);
        if (registerResult.IsSuccess)
        {
            return Ok("Пользователь успешно зарегистрирован!");
        }
        return BadRequest(registerResult.ErrorMessage);
    }

    [HttpGet("[action]")]
    [Authorize]
    public async Task<UserDto> GetUserAsync()
    {
        var userClaims = User;
        var user = await _authService.GetUserAsync(userClaims);
        return user;
    }
}