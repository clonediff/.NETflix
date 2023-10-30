using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsFiltered;

public record GetFilmsFilteredQuery(string? Name, int Page, int PageSize) : IQuery<PaginationDataDto<EnumDto<int>>>;