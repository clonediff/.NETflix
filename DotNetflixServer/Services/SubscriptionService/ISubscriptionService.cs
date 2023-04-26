using DtoLibrary;

namespace Services.SubscriptionService;

public interface ISubscriptionService
{
    Task<int> GetSubscriptionsCountAsync();
    Task<List<string>> GetAllUserSubscriptionsAsync(string userId);
    bool HaveCommonSubscriptions(List<string> userSubscriptions, List<string> filmSubscriptions);
    Task<PaginationDataDto<SubscriptionDto>> GetSubscriptionsFilteredAsync(string? name, int page);
    IEnumerable<FilmInSubscriptionDto> GetAllFilmsWithSubscriptionAsync(int subscriptionId, string? name);
    Task UpdateFilmsInSubscriptionAsync(int subscriptionId, IDictionary<int, bool> movies);
    Task AddSubscriptionAsync(AddSubscriptionDto dto);
    Task UpdateSubscriptionAsync(UpdateSubscriptionDto dto);
    Task DeleteSubscription(int subscriptionId);
    Task ChangeSubscriptionAvailabilityAsync(SubscriptionAvailabilityDto dto);
    Task PurchaseSubscriptionAsync(UserSubscriptionDto dto);
    Task ExtendSubscriptionAsync(UserSubscriptionDto dto);
}