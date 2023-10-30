using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.BehaviorMarkers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Behaviors;

public class TokenValidationBehavior<TRequest, TSuccess> : IPipelineBehavior<TRequest, Result<TSuccess, string>>
    where TRequest : IHasTokenValidation
{
    private readonly UserManager<User> _userManager;

    public TokenValidationBehavior(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<TSuccess, string>> Handle(TRequest request, RequestHandlerDelegate<Result<TSuccess, string>> next, CancellationToken cancellationToken)
    {
        var isVerifySuccess = await _userManager.VerifyUserTokenAsync(request.User, TokenOptions.DefaultProvider, request.Key, request.Token);
        if (!isVerifySuccess)
        {
            return "Код не совпадает или устарел";
        }

        return await next();
    }
}