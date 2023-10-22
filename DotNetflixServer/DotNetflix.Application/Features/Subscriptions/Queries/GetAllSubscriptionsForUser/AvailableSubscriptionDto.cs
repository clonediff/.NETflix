namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;

public record AvailableSubscriptionDto(int Id, string Name, int Cost, int? PeriodInDays, bool BelongsToUser, IEnumerable<string> FilmNames);
