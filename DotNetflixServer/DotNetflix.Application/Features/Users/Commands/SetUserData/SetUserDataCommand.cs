using System.Security.Claims;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Commands.SetUserData;

public record SetUserDataCommand(ClaimsPrincipal User, DateTime Birthdate, string UserName) : ICommand<Result<string, string>>;
