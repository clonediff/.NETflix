using Contracts;
using Contracts.Subscriptions;

namespace Services.Abstractions;

public interface ISubscriptionService
{
    IAsyncEnumerable<string> GetAllFilmNames(int subscriptionId);
    IEnumerable<AvailableSubscriptionDto> GetAllSubscriptions(string? userId);
    Task PurchaseSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto);
    Task ExtendSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto);
}