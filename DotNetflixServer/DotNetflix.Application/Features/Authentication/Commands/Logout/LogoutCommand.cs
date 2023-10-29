using System.Windows.Input;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using ICommand = DotNetflix.Abstractions.Cqrs.ICommand;

namespace DotNetflix.Application.Features.Authentication.Commands.Logout;

public record LogoutCommand() : ICommand;