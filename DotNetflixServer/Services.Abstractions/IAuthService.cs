using System.Security.Claims;
using Contracts.AuthDto;
using Contracts.Forms;
using DotNetflix.Application.Shared;

namespace Services.Abstractions;

public interface IAuthService
{
    Task<UserDto> GetUserAsync(ClaimsPrincipal user);
    Task<AuthResultDto> Login(LoginForm form);
    Task<AuthResultDto> Register(RegisterForm form);
    Task Logout();
}