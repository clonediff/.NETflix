using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Authentication.Commands.Register;

internal class RegistrationCommandHandler : ICommandHandler<RegistrationCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;

    public RegistrationCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string, string>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            Birthday = request.Birthday
        };
        
        var checkExistingEmail = await _userManager.FindByEmailAsync(user.Email);
        if (checkExistingEmail != null)
        {
            return new Result<string, string>(failure: "Ошибка регистрации. Попробуйте снова!");
        }
        
        var checkingExistingUserName = await _userManager.FindByNameAsync(user.UserName);
        if (checkingExistingUserName != null)
        {
            return new Result<string, string>(failure: "Ошибка регистрации. Попробуйте снова!");
        }

        var creatingResult = await _userManager.CreateAsync(user, request.Password);
        if (!creatingResult.Succeeded)
        {
            return new Result<string, string>(failure: "Ошибка регистрации. Попробуйте снова!");
        }

        await _userManager.AddToRoleAsync(user, "user");

        return new Result<string, string>(success: "Вы успешно зарегистрировались!");
    }
}