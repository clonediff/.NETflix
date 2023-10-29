using FluentValidation;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty()
            .WithMessage("Имя пользователя должно быть заполнено!");

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Пароль должен быть заполнен!");
    }
}