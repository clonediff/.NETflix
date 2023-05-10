namespace Contracts.Subscriptions;

public record GetUserSubscriptionDto(int Id, string SubscriptionName, int Cost, DateTime? Expires);