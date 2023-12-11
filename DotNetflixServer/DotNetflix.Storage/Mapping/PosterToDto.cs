using Contracts.Shared;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;

namespace DotNetflix.Storage.Mapping;

public static class PosterToDto
{
    public static PosterMetaDataDto ToPosterMetaDataDto(this MoviePosterMetadata entity)
    {
        return new PosterMetaDataDto(entity.Id, entity.Name, entity.FileName, entity.Resolution);
    }

    public static MoviePosterMetadata ToMoviePosterMetaData(this PosterMetaDataDto dto, Guid id, int movieId)
    {
        return new MoviePosterMetadata
        {
            Id = id,
            Name = dto.Name,
            FileName = dto.FileName,
            Resolution = dto.Resolution,
            MovieId = movieId
        };
    }
}