using Domain.Entities;
using DotNetflix.Application.Features.Films.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Films.Queries.GetAllFilms;

internal class GetAllFilmsQueryHandler : IQueryHandler<GetAllFilmsQuery, Dictionary<string, IEnumerable<MovieForMainPageDto>>>
{
    private readonly DbContext _dbContext;

    public GetAllFilmsQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Dictionary<string, IEnumerable<MovieForMainPageDto>>> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dbContext.Set<MovieInfo>()
            .Where(m => m.CategoryId != null)
            .Include(movie => movie.Category)
            .AsEnumerable()
            .Select(m => m.ToMovieForMainPageDto())
            .GroupBy(m => m.Category)
            .ToDictionary(g => g.Key, g => g.AsEnumerable()));
    }
}
