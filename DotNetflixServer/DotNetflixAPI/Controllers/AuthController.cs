using DotNetflix.Application.Features.Authentication.Commands.Login;
using DotNetflix.Application.Features.Authentication.Commands.Logout;
using DotNetflix.Application.Features.Authentication.Commands.Register;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginForm form)
    {
        var loginCommand = new LoginCommand(form.UserName,form.Password, form.Remember);
        var result = await _mediator.Send(loginCommand);
        return result.Match<IActionResult>(success: Ok, 
            failure: BadRequest);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] RegisterForm form)
    {
        var registrationCommand = new RegistrationCommand(form.Email, form.UserName, 
            form.Birthday, form.Password, form.ConfirmPassword);
        
        var result = await _mediator.Send(registrationCommand);
        return result.Match<IActionResult>(success: Ok, 
            failure: BadRequest);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Logout()
    {
        var logoutCommand = new LogoutCommand();
        await _mediator.Send(logoutCommand);                                                                        
        return Ok("Вы успешно вышли из аккаунта");
    }
}