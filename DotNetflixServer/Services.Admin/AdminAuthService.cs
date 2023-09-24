using Contracts.Admin.Authentication;
using Contracts.AuthDto;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Services.Admin.Abstractions;

namespace Services.Admin;

public class AdminAuthService : IAdminAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AdminAuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<AuthResultDto> Login(LoginForm login)
    {
        var user = await _userManager.FindByNameAsync(login.UserName);
        if (user == null)
            return new AuthResultDto("Неверный логин или пароль!");
        var roles = await _userManager.GetRolesAsync(user);
        if (!(roles.Contains("admin") || roles.Contains("manager")))
            return new AuthResultDto("У вас нет прав, чтобы войти сюда!");
        var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, true, false);
        if (result.Succeeded)
        {
            return new AuthResultDto();
        }

        return new AuthResultDto("Неверный логин или пароль!");
    }
    
    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}