using System.Windows.Input;
using ICommand = DotNetflix.CQRS.Abstractions.ICommand;

namespace DotNetflix.Application.Features.Authentication.Commands.Logout;

public record LogoutCommand() : CQRS.Abstractions.ICommand;