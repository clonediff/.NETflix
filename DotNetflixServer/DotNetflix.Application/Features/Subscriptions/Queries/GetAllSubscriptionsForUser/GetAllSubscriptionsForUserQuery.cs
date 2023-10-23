using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;

public record GetAllSubscriptionsForUserQuery(string? UserId) : IQuery<IEnumerable<AvailableSubscriptionDto>>;
