using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Users.Commands.BanUser;

public record BanUserCommand(string UserId, int Days) : ICommand<Result<DateTime,string>> , IHasUserIdValidation;