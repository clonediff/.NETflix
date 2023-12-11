using Contracts.Shared;
using DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class AddFilmDtoToCommand
{
    public static AddFilmCommand ToAddFilmCommand(this AddFilmDto dto)
    {
        return new AddFilmCommand(
            Name: dto.Name,
            Year: dto.Year,
            Description: dto.Description,
            ShortDescription: dto.ShortDescription,
            Slogan: dto.Slogan,
            Rating: dto.Rating,
            MovieLength: dto.MovieLength,
            AgeRating: dto.AgeRating,
            PosterUrl: dto.PosterUrl,
            Type: dto.Type,
            Category: dto.Category,
            Budget: dto.Budget,
            BudgetCurrency: dto.BudgetCurrency,
            FeesRussia: dto.FeesRussia,
            FeesRussiaCurrency: dto.FeesRussiaCurrency,
            FeesUsa: dto.FeesUsa,
            FeesUsaCurrency: dto.FeesUsaCurrency,
            FeesWorld: dto.FeesWorld,
            FeesWorldCurrency: dto.FeesWorldCurrency,
            Countries: dto.Countries,
            Genres: dto.Genres,
            Seasons: dto.Seasons,
            People: dto.People,
            TrailersMetaData: dto.TrailersMetaData ?? Enumerable.Empty<TrailerMetaDataDto>(),
            PostersMetaData: dto.PostersMetaData ?? Enumerable.Empty<PosterMetaDataDto>()
        );
    }
}