using Contracts.Admin.Films.Details;
using Domain.Entities;

namespace Mappers.Admin;

public static class MovieInfoToMovieDetailsDto
{
    public static MovieDetailsDto ToMovieDetailsDto(this MovieInfo movieInfo)
    {
        return new MovieDetailsDto
        (
            Name: movieInfo.Name,
            Year: movieInfo.Year,
            Description: movieInfo.Description,
            ShortDescription: movieInfo.ShortDescription,
            Slogan: movieInfo.Slogan,
            Rating: movieInfo.Rating,
            MovieLength: movieInfo.MovieLength,
            AgeRating: movieInfo.AgeRating,
            PosterUrl: movieInfo.PosterURL,
            Type: movieInfo.Type.Name,
            Category: movieInfo.Category?.Name,
            Budget: $"{movieInfo.Budget?.Value}{movieInfo.Budget?.Currency}",
            Fees: new FeesDetailsDto
            (
                World: $"{movieInfo.Fees?.World?.Value}{movieInfo.Fees?.World?.Currency}",
                Russia: $"{movieInfo.Fees?.Russia?.Value}{movieInfo.Fees?.Russia?.Currency}",
                Usa: $"{movieInfo.Fees?.USA?.Value}{movieInfo.Fees?.USA?.Currency}"
            ),
            Countries: movieInfo.Countries.Select(c => c.Country.Name),
            Genres: movieInfo.Genres.Select(g => g.Genre.Name),
            Seasons: movieInfo.SeasonsInfo?.Select(s => new SeasonDetailsDto(s.Number, s.EpisodesCount)),
            SubscriptionNames: movieInfo.Subscriptions.Select(s => s.Name),
            FilmCrew: movieInfo.Proffessions
                .Select(p => new PersonDetailsDto(p.Person.Name, p.Person.Photo, p.Profession.Name))
        );
    }
}