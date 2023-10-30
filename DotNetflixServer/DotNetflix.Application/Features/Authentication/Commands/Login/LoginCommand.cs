using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Authentication.Commands.Login;

public record LoginCommand(string Username, string Password, bool RememberUser) : ICommand<Result<string, string>>;