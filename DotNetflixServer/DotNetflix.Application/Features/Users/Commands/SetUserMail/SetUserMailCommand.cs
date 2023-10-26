using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Commands.SetUserMail;

public record SetUserMailCommand(User User, string Email, string Key, string Token) : ICommand<Result<string, string>>, IHasTokenValidation;
