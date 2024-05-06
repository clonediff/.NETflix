using DotNetflix.CQRS;
using MediatR;

namespace DotNetflix.Application.Features.JwtAuthentication.Commands.Register;

public record RegisterCommand : IRequest<Result<string, string>>
{
    public RegisterCommand(string email, DateTime birthday, string userName, string password, string confirmPassword)
    {
        Email = email;
        Birthday = birthday;
        UserName = userName;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string Email { get; init; }
    
    public DateTime Birthday { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
}