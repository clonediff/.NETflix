using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsCount;

internal class GetFilmsCountQueryHandler : IQueryHandler<GetFilmsCountQuery, int>
{
    private readonly DbContext _dbContext;

    public GetFilmsCountQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetFilmsCountQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<MovieInfo>().CountAsync(cancellationToken);
    }
}