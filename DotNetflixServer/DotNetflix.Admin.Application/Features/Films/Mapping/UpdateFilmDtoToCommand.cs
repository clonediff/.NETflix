using DotNetflix.Admin.Application.Features.Films.Commands.UpdateFilm;

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
            Seasons: dto.Seasons,
            SeasonsToDelete: dto.SeasonsToDelete,
            PeopleToAdd: dto.PeopleToAdd,
            PeopleToDelete: dto.PeopleToDelete
        );
    }
}