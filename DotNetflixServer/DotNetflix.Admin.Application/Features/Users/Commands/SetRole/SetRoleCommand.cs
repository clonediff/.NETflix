using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Admin.Application.Features.Users.Commands.SetRole;

public record SetRoleCommand(string UserId, string RoleId) : ICommand<Result<bool, string>>, IHasUserIdValidation;
