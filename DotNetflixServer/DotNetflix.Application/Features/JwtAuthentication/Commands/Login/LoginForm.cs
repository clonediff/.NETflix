namespace DotNetflix.Application.Features.JwtAuthentication.Commands.Login;

public class LoginForm
{
    public string UserName { get; set; } = default!;
    
    public string Password { get; set; } = default!;

    public bool Remember { get; set; }
}