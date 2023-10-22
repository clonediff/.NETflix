using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;

public record GetAllFilmNamesInSubscriptionQuery(int SubscriptionId) : IQuery<IEnumerable<string>>;
