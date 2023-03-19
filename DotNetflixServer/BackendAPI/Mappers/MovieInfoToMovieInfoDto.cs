using BackendAPI.Dto;
using DBModels.BusinessLogic;

namespace BackendAPI.Mappers;

public static class MovieInfoToMovieInfoDto
{
    public static MovieInfoDto ToMovieInfoDto(this MovieInfo movieInfo)
    {
        return new MovieInfoDto
        {
            Name = movieInfo.Name,
            Rating = movieInfo.Rating,
            PosterUrl = movieInfo.PosterURL
        };
    }
}