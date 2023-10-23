namespace DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;

public record GetUserSubscriptionDto(int Id, string SubscriptionName, int Cost, DateTime? Expires);
