using Domain.Entities;
using DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Mapping;

public static class SubscriptionToDto
{
    public static GetSubscriptionsFilteredDto ToGetSubscriptionsFilteredDto(this Subscription subscription)
    {
        return new GetSubscriptionsFilteredDto(
            subscription.Id, 
            subscription.Name, 
            subscription.Cost, 
            subscription.PeriodInDays, 
            subscription.IsAvailable, 
            subscription.Users.Count);
    }
}