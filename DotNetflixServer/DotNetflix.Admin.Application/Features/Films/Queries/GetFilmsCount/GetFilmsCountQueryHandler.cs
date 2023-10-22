using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmsCount;

internal class GetFilmsCountQueryHandler : IQueryHandler<GetFilmsCountQuery, int>
{
    private readonly ApplicationDBContext _dbContext;

    public GetFilmsCountQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetFilmsCountQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Movies.CountAsync(cancellationToken);
    }
}