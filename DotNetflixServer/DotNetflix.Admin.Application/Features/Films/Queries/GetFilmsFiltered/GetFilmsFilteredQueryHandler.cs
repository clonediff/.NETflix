using Domain.Entities;
using Domain.Extensions;
using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsFiltered;

internal class GetFilmsFilteredQueryHandler : IQueryHandler<GetFilmsFilteredQuery, PaginationDataDto<EnumDto<int>>>
{
    private readonly DbContext _dbContext;

    public GetFilmsFilteredQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationDataDto<EnumDto<int>>> Handle(GetFilmsFilteredQuery request, CancellationToken cancellationToken)
    {
        var filteredMovies = _dbContext.Set<MovieInfo>()
            .Where(x => request.Name == null || x.Name.Contains(request.Name));

        var filteredMoviesCount = await filteredMovies.CountAsync(cancellationToken);
        
        var movieNames = filteredMovies
            .Paginate(request.Page, request.PageSize)
            .Select(x => new EnumDto<int>(x.Id, x.Name));

        return new PaginationDataDto<EnumDto<int>>(movieNames, filteredMoviesCount);
    }
}