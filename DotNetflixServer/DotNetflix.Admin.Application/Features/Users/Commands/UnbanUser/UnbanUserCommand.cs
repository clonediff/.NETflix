using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Users.Commands.UnbanUser;

public record UnbanUserCommand(string UserId) : ICommand<Result<bool, string>>, IHasUserIdValidation;