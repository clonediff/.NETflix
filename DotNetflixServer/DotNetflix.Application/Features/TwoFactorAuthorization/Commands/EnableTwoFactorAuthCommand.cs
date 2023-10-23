using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.TwoFactorAuthorization.Commands;

public record EnableTwoFactorAuthCommand(User User, string Email, string Code) : ICommand<Result<string, string>>;