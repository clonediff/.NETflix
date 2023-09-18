using Contracts.Admin.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;

namespace DotNetflixAdminAPI;

[ApiController]
[Route("api/[controller]")]
public class AdminAuthController : ControllerBase
{
    private readonly IAdminAuthService _authService;

    public AdminAuthController(IAdminAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginForm form)
    {
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
}