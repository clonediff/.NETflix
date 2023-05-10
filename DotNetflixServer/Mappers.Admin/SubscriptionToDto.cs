using Contracts.Admin.Subscriptions;
using Domain.Entities;

namespace Mappers.Admin;

public static class SubscriptionToDto
{
    public static SubscriptionDto ToSubscriptionDto(this Subscription subscription)
    {
        return new SubscriptionDto(
            subscription.Id, 
            subscription.Name, 
            subscription.Cost, 
            subscription.PeriodInDays, 
            subscription.IsAvailable, 
            subscription.Users.Count);
    }
}