using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Logout;

public record LogoutCommand() : ICommand;