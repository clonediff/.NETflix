using Contracts.Admin.Authentication;
using Contracts.AuthDto;

namespace Services.Admin.Abstractions;

public interface IAdminAuthService
{
    Task<AuthResultDto> Login(LoginForm login);

    Task Logout();
}