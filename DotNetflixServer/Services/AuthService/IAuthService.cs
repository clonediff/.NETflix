using System.Security.Claims;
using BackendAPI.Models.Forms;
using DtoLibrary;
using DtoLibrary.AuthDto;

namespace Services.AuthService;

public interface IAuthService
{
    Task<UserDto> GetUserAsync(ClaimsPrincipal user);
    Task<AuthResultDto> Login(LoginForm form);
    Task<AuthResultDto> Register(RegisterForm form);
    Task Logout();
}