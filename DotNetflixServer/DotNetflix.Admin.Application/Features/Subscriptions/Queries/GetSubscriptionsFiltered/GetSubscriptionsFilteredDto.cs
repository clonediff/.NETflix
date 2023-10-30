namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;

public record GetSubscriptionsFilteredDto(int Id, string Name, int Cost, int? PeriodInDays, bool IsAvailable, int SubscribersCount);