using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Users.Commands.SetRole;

public record SetRoleCommand(string UserId, string RoleId) : ICommand<Result<bool,string>>;
