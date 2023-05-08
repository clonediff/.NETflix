using System.Collections;
using DtoLibrary;

namespace Services.SubscriptionService;

public interface ISubscriptionService
{
    Task<int> GetSubscriptionsCountAsync();
    Task<PaginationDataDto<SubscriptionDto>> GetSubscriptionsFilteredAsync(string? name, int page);
    IEnumerable<FilmInSubscriptionDto> GetAllFilms(int subscriptionId, string? name);
    Task UpdateFilmsInSubscriptionAsync(int subscriptionId, IDictionary<int, bool> movies);
    Task AddSubscriptionAsync(AddSubscriptionDto dto);
    Task UpdateSubscriptionAsync(UpdateSubscriptionDto dto);
    Task DeleteSubscription(int subscriptionId);
    Task ChangeSubscriptionAvailabilityAsync(SubscriptionAvailabilityDto dto);
    IAsyncEnumerable<string> GetAllFilmNames(int subscriptionId);
    IEnumerable<AvailableSubscriptionDto> GetAllSubscriptions(string? userId);
    Task PurchaseSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto);
    Task ExtendSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto);
}