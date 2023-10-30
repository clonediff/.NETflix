using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;

public record GetAllFilmNamesInSubscriptionQuery(int SubscriptionId) : IQuery<Result<IEnumerable<string>, string>>;
