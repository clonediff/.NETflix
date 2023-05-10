namespace Contracts.Admin.Subscriptions;

public record SubscriptionDto(int Id, string Name, int Cost, int? PeriodInDays, bool IsAvailable, int SubscribersCount);