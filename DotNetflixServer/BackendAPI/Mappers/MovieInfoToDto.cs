using BackendAPI.Dto;
using DBModels.BusinessLogic;

namespace BackendAPI.Mappers;

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
}