using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class AddFilmCommandToMovieInfo
{
    public static MovieInfo ToMovieInfo(this AddFilmCommand command)
    {
        var feesRussia = GetCurrencyValue(command.FeesRussia, command.FeesRussiaCurrency);
        var feesUsa = GetCurrencyValue(command.FeesUsa, command.FeesUsaCurrency);
        var feesWorld = GetCurrencyValue(command.FeesWorld, command.FeesWorldCurrency);
        
        return new MovieInfo
        {
            Name = command.Name,
            AgeRating = command.AgeRating,
            Description = command.Description,
            MovieLength = command.MovieLength,
            Genres = command.Genres.ToEntities(x => new GenreMovieInfo { GenreId = x }),
            Budget = GetCurrencyValue(command.Budget, command.BudgetCurrency),
            Fees = GetFees(feesRussia, feesUsa, feesWorld),
            PosterURL = command.PosterUrl,
            Year = command.Year,
            TypeId = command.Type,
            Slogan = command.Slogan,
            ShortDescription = command.ShortDescription,
            Rating = command.Rating,
            CategoryId = command.Category,
            Countries = command.Countries.ToEntities(x => new CountryMovieInfo { CountryId = x }),
            SeasonsInfo = (command.Seasons ?? Enumerable.Empty<AddSeasonDto>()).ToEntities(x => new SeasonsInfo { Number = x.Number, EpisodesCount = x.EpisodesCount }),
            Proffessions = command.People.ToEntities(x => x.ToPersonProfession())
        };
    }

    private static CurrencyValue? GetCurrencyValue(uint? value, string? currency)
    {
        return value is not null && currency is not null
            ? new CurrencyValue
                {
                    Currency = currency,
                    Value = value.Value
                }
            : null;
    }

    private static Fees GetFees(CurrencyValue? feesRussia, CurrencyValue? feesUsa, CurrencyValue? feesWorld)
    {
        return feesRussia is not null || feesUsa is not null || feesWorld is not null
            ? new Fees
                {
                    Russia = feesRussia,
                    USA = feesUsa,
                    World = feesWorld,
                }
            : null!;
    }
}