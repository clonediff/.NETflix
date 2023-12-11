using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Commands.UpdateFilm;
using DotNetflix.Admin.Application.Features.Films.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class UpdateFilmCommandToMovieInfo
{
    public static MovieInfo ToMovieInfo(this UpdateFilmCommand command)
    {
        return new MovieInfo
        {
            Id = command.Id,
            Name = command.Name,
            Year = command.Year,
            Description = command.Description,
            ShortDescription = command.ShortDescription,
            Slogan = command.Slogan,
            Rating = command.Rating,
            MovieLength = command.MovieLength,
            AgeRating = command.AgeRating,
            PosterURL = command.PosterUrl,
            TypeId = command.Type,
            CategoryId = command.Category,
            Budget = GetCurrencyValue(command.Budget),
            Fees = GetFees(command.Fees),
            SeasonsInfo = command.Seasons.ToEntities(x => new SeasonsInfo { Id = x.Id, Number = x.Number, EpisodesCount = x.EpisodesCount }),
            Proffessions = command.PeopleToAdd.ToEntities(x => x.ToPersonProfession())
        };
    }
    
    private static CurrencyValue? GetCurrencyValue(CurrencyValueDto dto)
    {
        return dto.Currency is null && dto.Value is null
            ? null
            : new CurrencyValue
            {
                Id = dto.Id,
                Currency = dto.Currency!,
                Value = dto.Value!.Value
            };
    }

    private static Fees GetFees(FeesDto dto)
    {
        return dto.FeesWorld is not null || dto.FeesRussia is not null || dto.FeesUsa is not null
            ? new Fees
                {
                    Id = dto.Id,
                    WorldId = dto.FeesWorld?.Id,
                    World = GetCurrencyValue(dto.FeesWorld!),
                    RussiaId = dto.FeesRussia?.Id,
                    Russia = GetCurrencyValue(dto.FeesRussia!),
                    USAId = dto.FeesUsa?.Id,
                    USA = GetCurrencyValue(dto.FeesUsa!)
                }
            : null!;
    }
}