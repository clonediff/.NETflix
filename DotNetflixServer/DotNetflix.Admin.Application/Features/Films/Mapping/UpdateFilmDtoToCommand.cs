using Contracts.Shared;
using DotNetflix.Admin.Application.Features.Films.Commands.UpdateFilm;
using DotNetflix.Admin.Application.Features.Films.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class UpdateFilmDtoToCommand
{
    public static UpdateFilmCommand ToUpdateFilmCommand(this UpdateFilmDto dto)
    {
        return new UpdateFilmCommand(
            Id: dto.Id,
            Name: dto.Name,
            Year: dto.Year,
            Description: dto.Description,
            ShortDescription: dto.ShortDescription,
            Slogan: dto.Slogan,
            MovieLength: dto.MovieLength,
            AgeRating: dto.AgeRating,
            Rating: dto.Rating,
            PosterUrl: dto.PosterUrl,
            Type: dto.Type,
            Category: dto.Category,
            Budget: dto.Budget,
            Countries: dto.Countries,
            Fees: dto.Fees,
            Genres: dto.Genres,
            Seasons: dto.Seasons ?? Enumerable.Empty<SeasonDto>(),
            SeasonsToDelete: dto.SeasonsToDelete ?? Enumerable.Empty<int>().ToList(),
            PeopleToAdd: dto.PeopleToAdd ?? Enumerable.Empty<AddOrUpdateFilmCrewDto>(),
            PeopleToDelete: dto.PeopleToDelete ?? Enumerable.Empty<DeletePersonFromFilmDto>().ToList(),
            TrailersMetaData: dto.TrailersMetaData ?? Enumerable.Empty<TrailerMetaDataDto>(),
            PostersMetaData: dto.PostersMetaData ?? Enumerable.Empty<PosterMetaDataDto>(),
            MetaDataToDelete: dto.MetaDataToDelete ?? Enumerable.Empty<Guid>()
        );
    }
}