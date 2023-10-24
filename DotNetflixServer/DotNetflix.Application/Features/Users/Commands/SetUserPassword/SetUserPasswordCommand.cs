using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Commands.SetUserPassword;

public record SetUserPasswordCommand(User User, string Password, string Key, string Code) : ICommand<Result<string, string>>, IHasCodeValidation;
