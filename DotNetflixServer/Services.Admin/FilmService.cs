using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Films;
using Contracts.Admin.Films.Details;
using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Extensions;
using Mappers.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

    public async Task<PaginationDataDto<EnumDto<int>>> GetFilmsFilteredAsync(int page, string? name)
    {
        var filteredMovies = _dbContext.Movies
            .Where(x => name == null || x.Name.Contains(name));

        var filteredMoviesCount = await filteredMovies.CountAsync();
        
        var movieNames = filteredMovies
            .Paginate(page, 25)
            .Select(x => new EnumDto<int>(x.Id, x.Name));

        return new PaginationDataDto<EnumDto<int>>(movieNames, filteredMoviesCount);
    }

    public async Task DeleteFilmAsync(int id)
    {
        var film = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (film is null)
            throw new NotFoundException("Не удалось найти фильм");

        _dbContext.Movies.Remove(film);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<MovieDto> GetFilmById(int id)
    {
        var film = await _dbContext.Movies
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Include(m => m.Genres)
                .ThenInclude(g => g.Genre)
            .Include(m => m.Type)
            .Include(m => m.Category)
            .Include(m => m.Budget)
            .Include(m => m.Countries)
                .ThenInclude(c => c.Country)
            .Include(m => m.Fees)
            .Include(m => m.Fees.World)
            .Include(m => m.Fees.Russia)
            .Include(m => m.Fees.USA)
            .Include(m => m.SeasonsInfo)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Person)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Profession)
            .FirstOrDefaultAsync();

        if (film is null)
            throw new NotFoundException("Не удалось найти фильм");
        
        return new MovieDto(
            Name: film.Name,
            Year: film.Year,
            Description: film.Description,
            ShortDescription: film.ShortDescription,
            Slogan: film.Slogan,
            Rating: film.Rating,
            MovieLength: film.MovieLength,
            AgeRating: film.AgeRating,
            PosterUrl: film.PosterURL,
            Type: new EnumDto<int>(film.Type.Id, film.Type.Name),
            Category: film.Category is null ? null : new EnumDto<int>(film.Category.Id, film.Category.Name),
            Budget: film.Budget is null
                ? null
                : new CurrencyValueDto(film.Budget.Id, film.Budget.Value, film.Budget.Currency),
            Fees: film.Fees is null
                ? null 
                : new FeesDto(
                    Id: film.Fees.Id,
                    FeesWorld: film.Fees?.World is null
                        ? null
                        : new CurrencyValueDto(film.Fees.World.Id, film.Fees.World.Value, film.Fees.World.Currency),
                    FeesRussia: film.Fees?.Russia is null
                        ? null
                        : new CurrencyValueDto(film.Fees.Russia.Id, film.Fees.Russia.Value, film.Fees.Russia.Currency),
                    FeesUsa: film.Fees?.USA is null
                        ? null
                        : new CurrencyValueDto(film.Fees.USA.Id, film.Fees.USA.Value, film.Fees.USA.Currency)),
            Genres: film.Genres.Select(g => new EnumDto<int>(g.GenreId, g.Genre.Name)),
            Countries: film.Countries.Select(c => new EnumDto<int>(c.CountryId, c.Country.Name)),
            Seasons: film.SeasonsInfo?.Select(s => new SeasonDto(s.Id, s.Number, s.EpisodesCount)),
            FilmCrew: film.Proffessions.Select(p =>
                new FilmCrewDto(p.PersonId, p.Person.Name, p.ProfessionId, p.Profession.Name)));
    }

    public async Task UpdateFilmAsync(UpdateFilmDto dto)
    {
        var movie = dto.ToMovieInfo();

        _dbContext.CountryMovieInfo.RemoveRange(
            _dbContext.CountryMovieInfo.Where(cmi => cmi.MovieInfoId == dto.Id));
        
        _dbContext.CountryMovieInfo.AddRange(
            _dbContext.Countries
                .Where(c => dto.Countries.Contains(c.Id))
                .Select(c => new CountryMovieInfo
                {
                    CountryId = c.Id,
                    MovieInfoId = dto.Id
                }));

        _dbContext.GenreMovieInfo.RemoveRange(
            _dbContext.GenreMovieInfo.Where(gmi => gmi.MovieInfoId == dto.Id));
        
        _dbContext.GenreMovieInfo.AddRange(
            _dbContext.Genres
                .Where(g => dto.Genres.Contains(g.Id))
                .Select(g => new GenreMovieInfo
                {
                    GenreId = g.Id,
                    MovieInfoId = dto.Id
                }));

        if (dto.SeasonsToDelete.Count != 0)
        {
            _dbContext.SeasonsInfos.RemoveRange(
                _dbContext.SeasonsInfos.Where(si => dto.SeasonsToDelete.Contains(si.Id)));
        }

        if (dto.PeopleToDelete.Count != 0)
        {
            _dbContext.PersonProffessionInMovie.RemoveRange(
                dto.PeopleToDelete.Select(ptd => new PersonProffessionInMovie
                {
                    PersonId = ptd.PersonId,
                    ProfessionId = ptd.ProfessionId,
                    MovieInfoId = dto.Id
                }));
        }

        _dbContext.Movies.Update(movie);

        await _dbContext.SaveChangesAsync();
        
        if (movie.Fees is null && dto.Fees.Id != 0)
        {
            var fees = await _dbContext.Fees.FirstOrDefaultAsync(f => f.Id == dto.Fees.Id);

            _dbContext.Entry(fees!).State = EntityState.Deleted;

            if (fees!.WorldId is not null)
                _dbContext.Entry(new CurrencyValue { Id = fees!.WorldId.Value }).State = EntityState.Deleted;
            if (fees!.RussiaId is not null)
                _dbContext.Entry(new CurrencyValue { Id = fees!.RussiaId.Value }).State = EntityState.Deleted;
            if (fees!.USAId is not null)
                _dbContext.Entry(new CurrencyValue { Id = fees!.USAId.Value }).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        if (movie.Budget is null && dto.Budget.Id != 0)
        {
            _dbContext.Entry(new CurrencyValue { Id = dto.Budget.Id }).State = EntityState.Deleted;
            
            await _dbContext.SaveChangesAsync();
        }

    }

    public async Task<MovieDetailsDto> GetFilmDetailsAsync(int id)
    {
        var movie = await _dbContext.Movies
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Include(m => m.Type)
            .Include(m => m.Category)
            .Include(m => m.Budget)
            .Include(m => m.Fees)
            .Include(m => m.Fees.World)
            .Include(m => m.Fees.Russia)
            .Include(m => m.Fees.USA)
            .Include(m => m.SeasonsInfo)
            .Include(m => m.Subscriptions)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Profession)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Person)
            .Include(m => m.Genres)
                .ThenInclude(g => g.Genre)
            .Include(m => m.Countries)
                .ThenInclude(c => c.Country)
            .FirstOrDefaultAsync();

        if (movie is null)
            throw new NotFoundException("Не удалось найти фильм");

        return movie.ToMovieDetailsDto();
    }
}