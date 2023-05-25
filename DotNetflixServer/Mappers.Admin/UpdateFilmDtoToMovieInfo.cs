using Contracts.Admin.Films;
using Domain.Entities;

namespace Mappers.Admin;

public static class UpdateFilmDtoToMovieInfo
{
    public static MovieInfo ToMovieInfo(this UpdateFilmDto dto)
    {
        return new MovieInfo
        {
            Id = dto.Id,
            Name = dto.Name,
            Year = dto.Year,
            Description = dto.Description,
            ShortDescription = dto.ShortDescription,
            Slogan = dto.Slogan,
            Rating = dto.Rating,
            MovieLength = dto.MovieLength,
            AgeRating = dto.AgeRating,
            PosterURL = dto.PosterUrl,
            TypeId = dto.Type,
            CategoryId = dto.Category,
            Budget = dto.Budget.ToCurrencyValue(),
            Fees = dto.Fees.FeesWorld is null && dto.Fees.FeesRussia is null && dto.Fees.FeesUsa is null
                ? null!
                : new Fees
                {
                    Id = dto.Fees.Id,
                    WorldId = dto.Fees.FeesWorld?.Id,
                    World = dto.Fees.FeesWorld!.ToCurrencyValue(),
                    RussiaId = dto.Fees.FeesRussia?.Id,
                    Russia = dto.Fees.FeesRussia!.ToCurrencyValue(),
                    USAId = dto.Fees.FeesUsa?.Id,
                    USA = dto.Fees.FeesUsa!.ToCurrencyValue()
                },
            SeasonsInfo = dto.Seasons?.Select(s => new SeasonsInfo
            {
                Id = s.Id,
                Number = s.Number,
                EpisodesCount = s.EpisodesCount
            }).ToList(),
            Proffessions = dto.PeopleToAdd.Select(p => new PersonProffessionInMovie
            {
                ProfessionId = p.ProfessionId,
                PersonId = p.Id,
                Person = p.Id != 0
                    ? null!
                    : new Person
                    {
                        Id = p.Id,
                        Name = p.Name!,
                        Photo = p.Photo
                    },
            }).ToList()
        };
    }
}