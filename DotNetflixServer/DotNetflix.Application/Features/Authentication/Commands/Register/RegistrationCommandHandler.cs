using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Authentication.Commands.Register;

internal class RegistrationCommandHandler : ICommandHandler<RegistrationCommand, Result<string, IEnumerable<string>>>
{
    private readonly UserManager<User> _userManager;

    public RegistrationCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string, IEnumerable<string>>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            Birthday = request.Birthday
        };

        var creatingResult = await _userManager.CreateAsync(user, request.Password);
        if (!creatingResult.Succeeded)
        {
            return new[] {"Ошибка регистрации. Попробуйте снова!"};
        }

        await _userManager.AddToRoleAsync(user, "user");

        return "Вы успешно зарегистрировались!";
    }
}