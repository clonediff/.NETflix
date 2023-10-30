using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Application.Features.TwoFactorAuthorization.Commands.EnableTwoFactorAuth;

public record EnableTwoFactorAuthCommand(User User, string Key, string Token) : ICommand<Result<string, string>>, IHasTokenValidation;
