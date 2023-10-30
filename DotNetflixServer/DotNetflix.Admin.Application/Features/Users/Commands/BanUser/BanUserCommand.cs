using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Admin.Application.Features.Users.Commands.BanUser;

public record BanUserCommand(string UserId, int Days) : ICommand<Result<DateTime,string>> , IHasUserIdValidation;