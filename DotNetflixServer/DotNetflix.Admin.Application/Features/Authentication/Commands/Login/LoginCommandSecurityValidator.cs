using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Login;

public class LoginCommandSecurityValidator : AbstractValidator<LoginCommand>
{
    private readonly UserManager<User> _userManager;
    
    public LoginCommandSecurityValidator(UserManager<User> userManager)
    {
        _userManager = userManager;

        RuleFor(x => x)
            .MustAsync(CheckUserRole)
            .WithMessage("У вас нет прав доступа к административной панели!");
    }

    private async Task<bool> CheckUserRole(LoginCommand command, CancellationToken token)
    {
        var user = await _userManager.FindByNameAsync(command.Username);
        if (user == null)
            return false;
        
        var roles = await _userManager.GetRolesAsync(user);
        return roles.Contains("admin") || roles.Contains("manager");
    }
}