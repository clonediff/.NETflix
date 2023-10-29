using Contracts.Admin.Authentication.Login;
using DotNetflix.Admin.Application.Features.Authentication.Commands.Login;
using DotNetflix.Admin.Application.Features.Authentication.Commands.Logout;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAdminAPI;

[ApiController]
[Route("api/[controller]")]
public class AdminAuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminAuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginForm form)
    {
        var loginCommand = new LoginCommand(form.UserName, form.Password);
        var result = await _mediator.Send(loginCommand);
        return result.Match<IActionResult>(success: Ok, 
            failure: BadRequest);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Logout()
    { 
        var logoutCommand = new LogoutCommand();
        await _mediator.Send(logoutCommand);                                                                        
        return Ok("Вы успешно вышли из аккаунта!");
    }
}