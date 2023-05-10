using Contracts.Admin.Films;
using Domain.Entities;

namespace Mappers.Admin;

public static class DtoToMovieInfo
{
    public static MovieInfo ToMovieInfo(this AddFilmDto dto)
    {
        var feesRussia = GetCurrencyValue(dto.FeesRussia, dto.FeesRussiaCurrency);
        var feesUsa = GetCurrencyValue(dto.FeesUsa, dto.FeesUsaCurrency);
        var feesWorld = GetCurrencyValue(dto.FeesWorld, dto.FeesWorldCurrency);
        
        return new MovieInfo
        {
            Name = dto.Name,
            AgeRating = dto.AgeRating,
            Description = dto.Description,
            MovieLength = dto.MovieLength,
            Genres = dto.Genres.Select(x => new GenreMovieInfo { GenreId = x }).ToList(),
            Budget = GetCurrencyValue(dto.Budget, dto.BudgetCurrency),
            Fees = feesRussia is not null ||
                   feesUsa is not null ||
                    feesWorld is not null ?
                    new Fees
                    {
                        Russia = feesRussia,
                        USA = feesUsa,
                        World = feesWorld,
                    } : null!,
            PosterURL = dto.PosterUrl,
            Year = dto.Year,
            TypeId = dto.Type,
            Slogan = dto.Slogan,
            ShortDescription = dto.ShortDescription,
            Rating = dto.Rating,
            CategoryId = dto.Category,
            Countries = dto.Countries.Select(x => new CountryMovieInfo { CountryId = x }).ToList(),
            SeasonsInfo = dto.Seasons?.Select(x => new SeasonsInfo { Number = x.Number, EpisodesCount = x.EpisodesCount }).ToList(),
            Proffessions = dto.People.Select(x => x.ToPersonProfession()).ToList()
        };
    }

    private static CurrencyValue? GetCurrencyValue(uint? value, string? currency)
        => value != null && currency != null ?
            new CurrencyValue
            {
                Currency = currency,
                Value = value.Value
            } : null;
}