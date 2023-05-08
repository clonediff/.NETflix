using DataAccess.Entities.BusinessLogic;
using DtoLibrary;

namespace Services.Mappers;

public static class SubscriptionToDto
{
    public static SubscriptionDto ToSubscriptionDto(this Subscription subscription)
    {
        return new SubscriptionDto
        {
            Id = subscription.Id,
            Cost = subscription.Cost,
            IsAvailable = subscription.IsAvailable,
            PeriodInDays = subscription.PeriodInDays,
            Name = subscription.Name,
            SubscribersCount = subscription.Users.Count
        };
    }
}