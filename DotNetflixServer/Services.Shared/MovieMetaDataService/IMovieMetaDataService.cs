namespace Services.Shared.MovieMetaDataService;

public interface IMovieMetaDataService
{
    Task<IEnumerable<TMetaData>> GetMetaDataAsync<TMetaData>(int movieId, string metaDataType);

    Task UpdateMetaDataAsync<TMetaData>(int movieId, Guid metaDataId, string metaDataType, TMetaData metaData);

    Task AddMetaDataAsync<TMetaData>(int movieId, string metaDataType, IEnumerable<TMetaData> metadata);

    Task DeleteMetaDataAsync(Guid metaDataId);

    Task DeleteMovieMetaDataAsync(int movieId);
}