using Domain.Entities;
using DotNetflix.CQRS;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.JwtAuthentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserStore<User> _userStore;

    public RegisterCommandHandler(UserManager<User> userManager,
        IUserStore<User> userStore)
    {
        _userManager = userManager;
        _userStore = userStore;
    }

    public async Task<Result<string, string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Email = request.Email,
            Birthday = request.Birthday,
            
        };
        
        await _userStore.SetUserNameAsync(user, request.UserName, cancellationToken);
        
        var checkPasswordRes = request.Password == request.ConfirmPassword;
        if (!checkPasswordRes)
            return new Result<string, string>(failure: "Пароли не совпадают!");

        var result = await _userManager.CreateAsync(user, request.Password);

        return !result.Succeeded 
            ? new Result<string, string>(failure: "Ошибка регистрации. Попробуйте снова!") 
            : new Result<string, string>(success: "Вы успешно зарегистрировались!");
    }
}