namespace DotNetflix.S3.Services;

public interface IS3StorageService
{
    /// <summary>
    /// Созать бакет
    /// </summary>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    public Task CreateBucketAsync(string bucketIdentifier);

    /// <summary>
    /// Удалить бакет
    /// </summary>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    /// <returns></returns>
    public Task RemoveBucketAsync(string bucketIdentifier);

    /// <summary>
    /// Проверить существует ли бакет 
    /// </summary>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    /// <returns>true если существует</returns>
    public Task<bool> BucketExistAsync(string bucketIdentifier);

    /// <summary>
    /// Положить файл в бакет
    /// </summary>
    /// <param name="fileStream">Файл в виде <see cref="Stream"/></param>
    /// <param name="fileIdentifier">уникальный идентификатор файла</param>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    public Task PutFileInBucketAsync(Stream fileStream, string fileIdentifier, string bucketIdentifier);

    /// <summary>
    /// Удалить файл из бакета
    /// </summary>
    /// <param name="fileIdentifier">уникальный идентификатор файла</param>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    public Task RemoveFileFromBucketAsync(string fileIdentifier, string bucketIdentifier);
    
    /// <summary>
    /// Получить файл из бакета
    /// </summary>
    /// <param name="fileIdentifier">уникальный идентификатор файла</param>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    /// <returns>Файл в виде <see cref="Stream"/> или null если бакет или файл не найден. </returns>
    public Task<Stream?> GetFileFromBucketAsync(string fileIdentifier, string bucketIdentifier);
}