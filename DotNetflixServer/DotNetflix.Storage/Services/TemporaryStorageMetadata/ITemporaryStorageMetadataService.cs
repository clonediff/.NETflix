namespace DotNetflix.Storage.Services.TemporaryStorageMetadata;

public interface ITemporaryStorageMetadataService
{
    /// <summary>
    /// Положить или обновить данные в временном хранилище
    /// </summary>
    /// <param name="data">данные</param>
    /// <param name="dataIdentifier">идентификатор данных</param>
    /// <param name="absoluteExpiration">Абсолютное время жизни данных в минутах</param>
    public Task SetStringAsync(string data, string dataIdentifier, uint absoluteExpiration);

    /// <summary>
    /// Удалить данные по идентификатору
    /// </summary>
    /// <param name="dataIdentifier">идентификатор данных</param>
    public Task RemoveAsync(string dataIdentifier);

    /// <summary>
    /// Получить данные по идентификатору
    /// </summary>
    /// <param name="dataIdentifier">идентификатор данных</param>
    /// <returns>данные или null если данные не найдены</returns>
    public Task<string?> GetStringAsync(string dataIdentifier);
}