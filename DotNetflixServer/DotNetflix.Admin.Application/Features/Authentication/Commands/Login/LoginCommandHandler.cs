﻿using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, Result<string, string>>
{
    private readonly SignInManager<User> _signInManager;

    public LoginCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public async Task<Result<string, string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);

        return result.Succeeded
            ? new Result<string, string>(success: "Вы успешно вошли в аккаунт!")
            : new Result<string, string>(failure: "Неверный логин или пароль!");
    }
}