using DataAccess.Entities.BusinessLogic;
using DtoLibrary;

namespace Services.SubscriptionService;

public interface ISubscriptionService
{
    Task<List<string>> GetAllSubscriptionsAsync(string userId);
    bool HaveCommonSubscriptions(List<string> userSubscriptions, List<string> filmSubscriptions);
    Task AddSubscriptionAsync(Subscription subscription);
    Task PurchaseSubscriptionAsync(SubscriptionDto dto);
    Task ExtendSubscriptionAsync(SubscriptionDto dto);
}