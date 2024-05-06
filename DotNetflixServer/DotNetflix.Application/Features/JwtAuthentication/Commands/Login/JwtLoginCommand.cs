using DotNetflix.CQRS;
using MediatR;

namespace DotNetflix.Application.Features.JwtAuthentication.Commands.Login;

public record JwtLoginCommand : IRequest<Result<string, string>>
{
    public JwtLoginCommand(string username, string password, bool rememberUser)
    {
        Username = username;
        Password = password;
        RememberUser = rememberUser;
    }

    public string Username { get; init; }
    public string Password { get; init; }
    
    public bool RememberUser { get; init; }
}