using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Application.Features.Users.Commands.SetUserPassword;

public record SetUserPasswordCommand(User User, string Password, string Key, string Token) : ICommand<Result<string, string>>, IHasTokenValidation;
