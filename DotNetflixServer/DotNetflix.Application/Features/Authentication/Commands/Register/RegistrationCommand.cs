using System.Windows.Input;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Authentication.Commands.Register;

public record RegistrationCommand(string Email, string UserName, DateTime Birthday,
    string Password, string ConfirmPassword) : ICommand<Result<string, IEnumerable<string>>>;
