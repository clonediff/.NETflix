namespace DotNetflix.Application.Features.User.Queries.GetAllUserSubscriptions;

public record GetUserSubscriptionDto(int Id, string SubscriptionName, int Cost, DateTime? Expires);
