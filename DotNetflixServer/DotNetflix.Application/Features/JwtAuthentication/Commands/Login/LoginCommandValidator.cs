using FluentValidation;

namespace DotNetflix.Application.Features.JwtAuthentication.Commands.Login;

public class LoginCommandValidator : AbstractValidator<JwtLoginCommand>
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