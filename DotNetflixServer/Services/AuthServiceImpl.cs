﻿using System.Security.Claims;
using Contracts.AuthDto;
using Contracts.Forms;
using Domain.Entities;
using DotNetflix.Application.Shared;
using DotNetflix.Application.Shared.Mapping;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions;

namespace Services;

public class AuthServiceImpl : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthServiceImpl(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<UserDto> GetUserAsync(ClaimsPrincipal user)
    {
        var userToDto = await _userManager.GetUserAsync(user);
        return userToDto?.ToUserDto()!;
    }

    public async Task<AuthResultDto> Login(LoginForm form)
    {
        var result = await _signInManager.PasswordSignInAsync(form.UserName, form.Password, form.Remember, false);
        if (result.Succeeded)
        {
            return new AuthResultDto();
        }

        return new AuthResultDto("Неверный логин или пароль!");
    }

    public async Task<AuthResultDto> Register(RegisterForm form)
    {
        if (form.Password != form.ConfirmPassword)
        {
            return new AuthResultDto("Разные пароли!");
        }
        
        var user = new User
        {
            UserName = form.UserName,
            Email = form.Email,
            Birthday = form.Birthday
        };
        //Поменять сообщения ошибок про существование пользователя
        var checkExistingEmail = await _userManager.FindByEmailAsync(user.Email);
        if (checkExistingEmail != null)
        {
            return new AuthResultDto("Ошибка регистрации. Попробуйте снова");
        }
        
        var checkingExistingUserName = await _userManager.FindByNameAsync(user.UserName);
        if (checkingExistingUserName != null)
        {
            return new AuthResultDto("Ошибка регистрации. Попробуйте снова");
        } 

        var creatingResult = await _userManager.CreateAsync(user,form.Password);
        if (!creatingResult.Succeeded)
        {
            return new AuthResultDto(creatingResult.Errors.FirstOrDefault()?.Description!);
        }

        await _userManager.AddToRoleAsync(user, "user");

        return new AuthResultDto();
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}