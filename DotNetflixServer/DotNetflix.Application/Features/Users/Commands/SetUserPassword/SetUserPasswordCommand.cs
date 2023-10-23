using System.Security.Claims;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Commands.SetUserPassword;

public record SetUserPasswordCommand(ClaimsPrincipal User, string Password, string Code) : ICommand<Result<string, string>>;
