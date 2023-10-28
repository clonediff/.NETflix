using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Features.Films.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Films.Queries.GetAllFilms;

internal class GetAllFilmsQueryHandler : IQueryHandler<GetAllFilmsQuery, Dictionary<string, IEnumerable<MovieForMainPageDto>>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllFilmsQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Dictionary<string, IEnumerable<MovieForMainPageDto>>> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dbContext.Movies
            .Where(m => m.CategoryId != null)
            .Include(movie => movie.Category)
            .AsEnumerable()
            .Select(m => m.ToMovieForMainPageDto())
            .GroupBy(m => m.Category)
            .ToDictionary(g => g.Key, g => g.AsEnumerable()));
    }
}
