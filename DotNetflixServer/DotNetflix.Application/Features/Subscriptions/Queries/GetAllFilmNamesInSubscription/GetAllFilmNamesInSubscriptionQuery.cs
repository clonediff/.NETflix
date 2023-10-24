using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;

public record GetAllFilmNamesInSubscriptionQuery(int SubscriptionId) : IQuery<Result<IEnumerable<string>, string>>;
