using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Films;
using DataAccess;
using Domain.Extensions;
using Mappers.Admin;
using Microsoft.EntityFrameworkCore;
using Services.Admin.Abstractions;

namespace Services.Admin;

public class FilmService : IFilmService
{
    private readonly ApplicationDBContext _dbContext;

    public FilmService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetFilmsCountAsync()
    {
        return await _dbContext.Movies.CountAsync();
    }

    public async Task AddFilmAsync(AddFilmDto dto)
    {
        var movie = dto.ToMovieInfo();
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PaginationDataDto<string>> GetFilmsFilteredAsync(int page, string? name)
    {
        var filteredMovies = _dbContext.Movies
            .Where(x => name == null || x.Name.Contains(name));

        var filteredMoviesCount = await filteredMovies.CountAsync();
        
        var movieNames = filteredMovies
            .Paginate(page, 25)
            .Select(x => x.Name);

        return new PaginationDataDto<string>(movieNames, filteredMoviesCount);
    }
}