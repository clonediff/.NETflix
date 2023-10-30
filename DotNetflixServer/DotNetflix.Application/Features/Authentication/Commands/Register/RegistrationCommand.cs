using System.Windows.Input;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Authentication.Commands.Register;

public record RegistrationCommand(string Email, string UserName, DateTime Birthday,
    string Password, string ConfirmPassword) : ICommand<Result<string, string>>;
