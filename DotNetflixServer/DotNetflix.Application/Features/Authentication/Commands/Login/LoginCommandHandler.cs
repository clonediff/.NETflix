using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Authentication.Commands.Login;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, Result<string, IEnumerable<string>>>
{
    private readonly SignInManager<User> _signInManager;

    public LoginCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<Result<string, IEnumerable<string>>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, request.RememberUser, false);

        return result.Succeeded
            ? "Вы успешно вошли в аккаунт!"
            : new[]{"Неверный логин или пароль!"};
    }
}