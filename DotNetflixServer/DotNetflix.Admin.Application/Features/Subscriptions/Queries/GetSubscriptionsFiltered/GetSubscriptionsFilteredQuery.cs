using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;

public record GetSubscriptionsFilteredQuery(string? Name, int Page, int PageSize) : IQuery<PaginationDataDto<GetSubscriptionsFilteredDto>>;