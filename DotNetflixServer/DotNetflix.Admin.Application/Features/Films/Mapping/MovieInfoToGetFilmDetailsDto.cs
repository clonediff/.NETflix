using Contracts.Shared;
using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;
using DotNetflix.Admin.Application.Features.Films.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class MovieInfoToGetFilmDetailsDto
{
    public static GetFilmDetailsDto ToMovieDetailsDto(this MovieInfo movieInfo,
        IEnumerable<TrailerMetaDataDto> trailersMetaData, 
        IEnumerable<PosterMetaDataDto> postersMetaData)
    {
        return new GetFilmDetailsDto(
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
            Fees: GetFeesDetailsDtoDto(movieInfo.Fees),
            Countries: movieInfo.Countries.Select(c => c.Country.Name),
            Genres: movieInfo.Genres.Select(g => g.Genre.Name),
            Seasons: movieInfo.SeasonsInfo?.Select(s => new GetSeasonDetailsDto(s.Number, s.EpisodesCount)),
            SubscriptionNames: movieInfo.Subscriptions.Select(s => s.Name),
            FilmCrew: movieInfo.Proffessions
                .Select(p => new GetPersonDetailsDto(p.Person.Name, p.Person.Photo, p.Profession.Name)),
            TrailersMetaData: trailersMetaData,
            PostersMetaData: postersMetaData
        );
    }

    private static GetFeesDetailsDto GetFeesDetailsDtoDto(Fees fees)
    {
        return new GetFeesDetailsDto(
            World: $"{fees?.World?.Value}{fees?.World?.Currency}",
            Russia: $"{fees?.Russia?.Value}{fees?.Russia?.Currency}",
            Usa: $"{fees?.USA?.Value}{fees?.USA?.Currency}"
        );
    }
}