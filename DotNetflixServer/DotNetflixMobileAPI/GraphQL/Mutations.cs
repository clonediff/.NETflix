using Contracts.Shared;
using DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;
using DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;
using DotNetflix.Application.Features.Subscriptions.Shared;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflixMobileAPI.GraphQL.Models;
using GraphQL;
using MediatR;

namespace DotNetflixMobileAPI.GraphQL;

public enum SubscriptionActionType
{
    Purchase,
    Extend   
}

public class Mutations
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Mutations(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    [Authorize]
    public async Task<GraphQLResponse> SubscriptionAction(SubscriptionActionType type, int subscriptionId, CardDataDto cardDataDto)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var userId = httpContext!.Request.Headers.Authorization.ToString();

        if (userId is null)
        {
            return "Неверный идентификатор пользователя";
        }

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        ICommand<Result<int, string>> command = type switch
        {
            SubscriptionActionType.Purchase => new PurchaseSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto),
            SubscriptionActionType.Extend => new ExtendSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto),
            _ => throw new NotImplementedException(),
        };
        var result = await mediator.Send(command);

        return result.Match(
            _ => new GraphQLResponse(false),
            x => new GraphQLResponse(true, x)
        );
    }
}