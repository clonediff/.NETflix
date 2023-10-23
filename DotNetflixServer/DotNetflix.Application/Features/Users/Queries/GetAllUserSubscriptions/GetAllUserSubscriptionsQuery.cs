using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;

public record GetAllUserSubscriptionsQuery(string UserId) : IQuery<IEnumerable<GetUserSubscriptionDto>>;
