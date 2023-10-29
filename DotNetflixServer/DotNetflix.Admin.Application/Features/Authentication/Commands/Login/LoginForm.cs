namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Login;

public class LoginForm
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}