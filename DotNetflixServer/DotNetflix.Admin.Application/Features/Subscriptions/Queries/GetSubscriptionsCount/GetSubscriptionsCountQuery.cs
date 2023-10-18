using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsCount;

public record GetSubscriptionsCountQuery : IQuery<int>;