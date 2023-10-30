using System.Security.Claims;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Users.Commands.SetUserData;

public record SetUserDataCommand(ClaimsPrincipal User, DateTime Birthdate, string UserName) : ICommand<Result<string, string>>;
