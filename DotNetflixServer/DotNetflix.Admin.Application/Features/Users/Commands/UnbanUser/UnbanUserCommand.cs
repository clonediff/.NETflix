using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Admin.Application.Features.Users.Commands.UnbanUser;

public record UnbanUserCommand(string UserId) : ICommand<Result<bool, string>>, IHasUserIdValidation;