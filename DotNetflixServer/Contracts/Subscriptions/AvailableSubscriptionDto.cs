namespace Contracts.Subscriptions;

public record AvailableSubscriptionDto(int Id, string Name, int Cost, int? PeriodInDays, bool BelongsToUser, IEnumerable<string> FilmNames);