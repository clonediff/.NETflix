using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;

public record GetSubscriptionsFilteredQuery(string? Name, int Page, int PageSize) : IQuery<PaginationDataDto<GetSubscriptionsFilteredDto>>;