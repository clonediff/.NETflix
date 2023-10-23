using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.User.Queries.GetAllUserSubscriptions;

public record GetAllUserSubscriptionsQuery(string UserId) : IQuery<IEnumerable<GetUserSubscriptionDto>>;
