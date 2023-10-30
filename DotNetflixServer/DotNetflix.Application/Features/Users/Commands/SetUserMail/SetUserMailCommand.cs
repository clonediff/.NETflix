using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Application.Features.Users.Commands.SetUserMail;

public record SetUserMailCommand(User User, string Email, string Key, string Token) : ICommand<Result<string, string>>, IHasTokenValidation;
