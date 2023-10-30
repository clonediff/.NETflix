using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsCount;

public record GetSubscriptionsCountQuery : IQuery<int>;