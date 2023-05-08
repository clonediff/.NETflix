using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using DtoLibrary.MoviePage;

namespace Services.Mappers;

public static class MovieInfoToDto
{
    public static MovieForMainPageDto ToMovieForMainPageDto(this MovieInfo movieInfo)
    {
        return new MovieForMainPageDto
        {
            Id = movieInfo.Id,
            Name = movieInfo.Name,
            Rating = movieInfo.Rating,
            PosterUrl = movieInfo.PosterURL,
            Category = movieInfo.Category.Name
        };
    }

    public static MovieForSearchPageDto ToMovieForSearchPageDto(this MovieInfo movieInfo)
    {
        return new MovieForSearchPageDto
        {
            Id = movieInfo.Id,
            Name = movieInfo.Name,
            Rating = movieInfo.Rating,
            PosterUrl = movieInfo.PosterURL
        };
    }

    public static MovieForMoviePageDto ToMovieForMoviePageDto(this MovieInfo movieInfo)
    {
        return new MovieForMoviePageDto
        {
            Id = movieInfo.Id,
            Name = movieInfo.Name,
            Year = movieInfo.Year,
            Description = movieInfo.Description,
            ShortDescription = movieInfo.ShortDescription,
            Slogan = movieInfo.Slogan,
            Rating = movieInfo.Rating,
            MovieLength = movieInfo.MovieLength,
            AgeRating = movieInfo.AgeRating,
            PosterURL = movieInfo.PosterURL,
            Type = movieInfo.Type.Name,
            Category = movieInfo.Category?.Name,
            Budget = $"{movieInfo.Budget?.Value}{movieInfo.Budget?.Currency}",

            Fees = new FeesForMoviePageDto
            {
                World = $"{movieInfo.Fees?.World?.Value}{movieInfo.Fees?.World?.Currency}",
                Russia = $"{movieInfo.Fees?.Russia?.Value}{movieInfo.Fees?.Russia?.Currency}",
                USA = $"{movieInfo.Fees?.USA?.Value}{movieInfo.Fees?.USA?.Currency}"
            },

            Countries = movieInfo.Countries.Select(c => c.Country.Name).ToList(),
            Genres = movieInfo.Genres.Select(g => g.Genre.Name).ToList(),

            SeasonsInfo = movieInfo.SeasonsInfo.Select(s => 
                new SeasonsInfoForMoviePageDto
                {
                    Number= s.Number,
                    EpisodesCount= s.EpisodesCount,
                }).ToList(),

            Proffessions = movieInfo.Proffessions
                .Select(p =>
                    new PersonForMoviePageDto
                    {
                        Name = p.Person.Name,
                        Photo = p.Person.Photo,
                        Profession = p.Profession.Name
                    })
                .GroupBy(p => p.Profession)
                .Select(g => new { Profession = g.Key, People = g }),
        };
    }
}