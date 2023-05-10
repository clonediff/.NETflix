using System.Security.Claims;
using Contracts;
using Contracts.AuthDto;
using Contracts.Forms;

namespace Services.Abstractions;

public interface IAuthService
{
    Task<UserDto> GetUserAsync(ClaimsPrincipal user);
    Task<AuthResultDto> Login(LoginForm form);
    Task<AuthResultDto> Register(RegisterForm form);
    Task Logout();
}