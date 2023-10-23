using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;
using DotNetflix.Admin.Application.Features.Films.Shared;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class MovieInfoToGetFilmByIdDto
{
    public static GetFilmByIdDto ToGetFilmByIdDto(this MovieInfo movieInfo)
    {
        return new GetFilmByIdDto(
            Name: movieInfo.Name,
            Year: movieInfo.Year,
            Description: movieInfo.Description,
            ShortDescription: movieInfo.ShortDescription,
            Slogan: movieInfo.Slogan,
            Rating: movieInfo.Rating,
            MovieLength: movieInfo.MovieLength,
            AgeRating: movieInfo.AgeRating,
            PosterUrl: movieInfo.PosterURL,
            Type: new EnumDto<int>(movieInfo.Type.Id, movieInfo.Type.Name),
            Category: GetNullableDto(movieInfo.Category, x => new EnumDto<int>(x.Id, x.Name)),
            Budget: GetNullableDto(movieInfo.Budget, x => new CurrencyValueDto(x.Id, x.Value, x.Currency)),
            Fees: GetFeesDto(movieInfo.Fees),
            Genres: movieInfo.Genres.Select(g => new EnumDto<int>(g.GenreId, g.Genre.Name)),
            Countries: movieInfo.Countries.Select(c => new EnumDto<int>(c.CountryId, c.Country.Name)),
            Seasons: movieInfo.SeasonsInfo?.Select(s => new SeasonDto(s.Id, s.Number, s.EpisodesCount)),
            FilmCrew: movieInfo.Proffessions.Select(p =>
                new GetFilmCrewDto(p.PersonId, p.Person.Name, p.ProfessionId, p.Profession.Name))
        );
    }
    
    public static TOut? GetNullableDto<TIn, TOut>(TIn? dto, Func<TIn, TOut> transformer)
    {
        return dto is null 
            ? default 
            : transformer(dto);
    }

    public static FeesDto GetFeesDto(Fees fees)
    {
        return new FeesDto(
            Id: fees.Id,
            FeesWorld: GetNullableDto(fees.World, x => new CurrencyValueDto(x.Id, x.Value, x.Currency)),
            FeesRussia: GetNullableDto(fees.Russia, x => new CurrencyValueDto(x.Id, x.Value, x.Currency)),
            FeesUsa: GetNullableDto(fees.USA, x => new CurrencyValueDto(x.Id, x.Value, x.Currency))
        );
    }
}