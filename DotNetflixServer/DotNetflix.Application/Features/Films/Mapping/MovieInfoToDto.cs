using Contracts.Shared;
using Domain.Entities;
using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmById;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;

namespace DotNetflix.Application.Features.Films.Mapping;

public static class MovieInfoToDto
{
    public static MovieForSearchPageDto ToMovieForSearchPageDto(this MovieInfo movieInfo)
    {
        return new MovieForSearchPageDto
        (
            Id: movieInfo.Id,
            Name: movieInfo.Name,
            Rating: movieInfo.Rating,
            PosterUrl: movieInfo.PosterURL!
        );
    }
    
    public static MovieForMainPageDto ToMovieForMainPageDto(this MovieInfo movieInfo)
    {
        return new MovieForMainPageDto
        (
            Id: movieInfo.Id,
            Name: movieInfo.Name,
            Rating: movieInfo.Rating,
            PosterUrl: movieInfo.PosterURL!,
            Category: movieInfo.Category!.Name
        );
    }

    public static MovieForMoviePageDto ToMovieForMoviePageDto(this MovieInfo movieInfo,
        IEnumerable<TrailerMetaDataDto> trailersMetaData,
        IEnumerable<PosterMetaDataDto> postersMetaData)
    {
        return new MovieForMoviePageDto
        (
            movieInfo.Id,
            movieInfo.Name,
            movieInfo.Year,
            movieInfo.Description,
            movieInfo.ShortDescription,
            movieInfo.Slogan,
            movieInfo.Rating,
            movieInfo.MovieLength,
            movieInfo.AgeRating,
            movieInfo.PosterURL,
            movieInfo.Type.Name,
            movieInfo.Category?.Name,
            $"{movieInfo.Budget?.Value}{movieInfo.Budget?.Currency}",

            new FeesDto
            (
                World: $"{movieInfo.Fees?.World?.Value}{movieInfo.Fees?.World?.Currency}",
                Russia: $"{movieInfo.Fees?.Russia?.Value}{movieInfo.Fees?.Russia?.Currency}",
                Usa: $"{movieInfo.Fees?.USA?.Value}{movieInfo.Fees?.USA?.Currency}"
            ),

            movieInfo.Countries
                .Select(c => new CountryDto(c.Country.Name, c.Country.Lat, c.Country.Lng))
                .ToList(),
            
            movieInfo.Genres
                .Select(g => g.Genre.Name)
                .ToList(),

            movieInfo.SeasonsInfo!
                .Select(s => new SeasonDto(s.Number, s.EpisodesCount))
                .ToList(),

            trailersMetaData,
            
            postersMetaData,
            
            movieInfo.Proffessions
                .Select(p => new PersonDto(p.Person.Name, p.Person.Photo, p.Profession.Name))
                .GroupBy(p => p.Profession)
                .ToDictionary(g => g.Key, g => g.AsEnumerable())
        );
    }
}
