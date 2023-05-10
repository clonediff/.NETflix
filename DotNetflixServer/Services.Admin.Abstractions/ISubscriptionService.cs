using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Subscriptions;

namespace Services.Admin.Abstractions;

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
}