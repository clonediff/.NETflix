using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Login;

public record LoginCommand(string Username, string Password) : ICommand<Result<string, string>>;