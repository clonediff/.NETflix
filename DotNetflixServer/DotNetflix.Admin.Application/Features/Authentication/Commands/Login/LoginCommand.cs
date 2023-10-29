using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Login;

public record LoginCommand(string Username, string Password) : ICommand<Result<string, string>>;