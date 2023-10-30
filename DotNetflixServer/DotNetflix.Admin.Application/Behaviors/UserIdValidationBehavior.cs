using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.BehaviorMarkers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Admin.Application.Behaviors;

public class UserIdValidationBehavior<TRequest, TSuccess> : IPipelineBehavior<TRequest, Result<TSuccess, string>>
    where TRequest : IHasUserIdValidation
{
    private readonly UserManager<User> _userManager;

    public UserIdValidationBehavior(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Result<TSuccess, string>> Handle(
        TRequest request,
        RequestHandlerDelegate<Result<TSuccess, string>> next,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        
        if (user == null)
            return "Не удалось найти пользователя";
        
        return await next();
    }
}