using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Authentication.Commands.Register;

public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
{
    private readonly UserManager<User> _userManager;

    public RegistrationCommandValidator(UserManager<User> userManager)
    {
        _userManager = userManager;
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email-адрес должен быть заполнен!");
        
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("Имя пользователя должно быть заполнено!");
        
        RuleFor(x => x.Birthday)
            .NotEmpty()
            .WithMessage("Дата рождения должна быть заполнена!");
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Подтверждение пароля должно быть заполнено!");
        
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Пароли не совпадают!");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Пароль должен быть заполнен!");

        RuleFor(x => x)
            .MustAsync(ValidateExistingEmail)
            .WithName(x => nameof(x.Email))
            .WithMessage("Ошибка регистрации. Попробуйте снова!");
        
        RuleFor(x => x)
            .MustAsync(ValidateExistingUserName)
            .WithName(x => nameof(x.UserName))
            .WithMessage("Ошибка регистрации. Попробуйте снова!");
    }

    private async Task<bool> ValidateExistingEmail(RegistrationCommand command, CancellationToken token)
    {
        var checkExistingEmail = await _userManager.FindByEmailAsync(command.Email);
        return checkExistingEmail == null;
    }
    
    private async Task<bool> ValidateExistingUserName(RegistrationCommand command, CancellationToken token)
    {
        var checkingExistingUserName = await _userManager.FindByNameAsync(command.UserName);
        return checkingExistingUserName == null;
    }
}