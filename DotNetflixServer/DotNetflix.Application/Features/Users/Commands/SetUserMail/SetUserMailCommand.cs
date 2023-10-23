using System.Security.Claims;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Commands.SetUserMail;

public record SetUserMailCommand(ClaimsPrincipal User, string Email, string Code) : ICommand<Result<string, string>>;
