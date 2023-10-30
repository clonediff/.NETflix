using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;

public record GetAllSubscriptionsForUserQuery(string? UserId) : IQuery<IEnumerable<AvailableSubscriptionDto>>;
