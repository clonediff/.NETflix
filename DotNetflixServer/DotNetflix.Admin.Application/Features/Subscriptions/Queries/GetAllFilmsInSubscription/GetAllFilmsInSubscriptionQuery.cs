using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetAllFilmsInSubscription;

public record GetAllFilmsInSubscriptionQuery(int SubscriptionId, string? Name) : IQuery<IEnumerable<GetAllFilmsInSubscriptionDto>>;