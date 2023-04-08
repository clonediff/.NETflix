using AdminBackendAPI.Dto;
using DataAccess.Entities.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class DtoToMovieInfo
    {
        public static MovieInfo ToMovieInfo(this FilmInsertDto dto)
        {
            var feesRussia = GetCurrencyValue(dto.FeesRussia, dto.FeesRussiaCurrency);
            var feesUsa = GetCurrencyValue(dto.FeesUsa, dto.FeesUsaCurrency);
            var feesWorld = GetCurrencyValue(dto.FeesWorld, dto.FeesWorldCurrency);
            var x = new MovieInfo
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
                PosterURL = dto.PosterURL,
                Year = dto.Year,
                TypeId = dto.Type,
                Slogan = dto.Slogan,
                ShortDescription = dto.ShortDescription,
                Rating = dto.Rating,
                CategoryId = dto.Category,
                Countries = dto.Countries.Select(x => new CountryMovieInfo { CountryId = x }).ToList(),
                SeasonsInfo = dto.Seasons?.Select(x => new SeasonsInfo { Number = x.Number, EpisodesCount = x.EpisodesCount }).ToList(),
                Proffessions = dto.People.Select(x => new PersonProffessionInMovie { ProfessionId = x.Profession ,
                    PersonId = x.Id,
                    Person = x.Id != 0 ? null! : new Person
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Photo = x.Photo,
                    } }).ToList()
            };
            return x;
        }

        private static CurrencyValue? GetCurrencyValue(uint? value, string? currency)
            => value != null && currency != null ?
                new CurrencyValue
                {
                    Currency = currency,
                    Value = value.Value
                } : null;
    }
}
