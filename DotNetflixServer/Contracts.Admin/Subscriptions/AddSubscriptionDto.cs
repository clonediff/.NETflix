namespace Contracts.Admin.Subscriptions;

public record AddSubscriptionDto(string Name, int Cost, int? PeriodInDays);