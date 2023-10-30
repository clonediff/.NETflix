using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Logout;

public record LogoutCommand() : ICommand;