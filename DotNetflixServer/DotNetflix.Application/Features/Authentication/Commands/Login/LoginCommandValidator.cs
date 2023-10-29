using FluentValidation;

namespace DotNetflix.Application.Features.Authentication.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Имя пользователя должно быть заполнено!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Пароль должен быть заполнен!");
    }
}