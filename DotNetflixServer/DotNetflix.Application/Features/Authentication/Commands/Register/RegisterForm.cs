
namespace DotNetflix.Application.Features.Authentication.Commands.Register;

public class RegisterForm
{
    public string Email { get; set; } = default!;
    
    public string UserName { get; set; } = default!;

    public DateTime Birthday { get; set; }
    
    public string Password { get; set; } = default!;
    
    public string ConfirmPassword { get; set; } = default!;
}