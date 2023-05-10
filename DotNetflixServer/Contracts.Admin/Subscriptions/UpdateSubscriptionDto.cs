namespace Contracts.Admin.Subscriptions;

public record UpdateSubscriptionDto(int Id, string Name, int Cost, int? PeriodInDays);