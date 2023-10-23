using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsFiltered;

public record GetFilmsFilteredQuery(string? Name, int Page, int PageSize) : IQuery<PaginationDataDto<EnumDto<int>>>;