using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Infrastructure.EmailService;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TokenController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;

    public TokenController(UserManager<User> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
    }
    
    [HttpGet("[action]")]
    public async Task Send2FATokenAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user!);
        await _emailService.SendEmailAsync(user!.Email!, "Код для двухфакторной аутентификации", code);
    }
    
    [HttpGet("[action]")]
    public async Task SendChangePasswordTokenAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var code = await _userManager.GeneratePasswordResetTokenAsync(user!);
        await _emailService.SendEmailAsync(user!.Email!, "Код для изменения пароля", code);
    }

    [HttpGet("[action]")]
    public async Task SendChangeMailTokenAsync([FromQuery] string newEmail)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var code = await _userManager.GenerateChangeEmailTokenAsync(user!, newEmail);
        await _emailService.SendEmailAsync(user!.Email!, $"Код для изменения почты с {user.Email} на {newEmail}", code);
    }
}
