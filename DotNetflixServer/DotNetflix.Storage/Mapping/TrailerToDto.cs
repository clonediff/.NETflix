using Contracts.Shared;
using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;

namespace DotNetflix.Storage.Mapping;

public static class TrailerToDto
{
    public static TrailerMetaDataDto ToTrailerMetaDataDto(this MovieTrailerMetadata entity)
    {
        return new TrailerMetaDataDto(entity.Id, entity.Name, entity.FileName, entity.Date, entity.Language, entity.Resolution);
    }

    public static MovieTrailerMetadata ToMovieTrailerMetaData(this TrailerMetaDataDto dto, Guid id, int movieId)
    {
        return new MovieTrailerMetadata
        {
            Id = id,
            Name = dto.Name,
            FileName = dto.FileName,
            Date = dto.Date,
            Language = dto.Language,
            Resolution = dto.Resolution,
            MovieId = movieId
        };
    }
}