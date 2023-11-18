namespace Services.Infrastructure.S3;

public interface IS3Storage
{
    /// <summary>
    /// Созать бакет
    /// </summary>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    public Task CreateBucket(string bucketIdentifier);

    /// <summary>
    /// Удалить бакет
    /// </summary>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    /// <returns></returns>
    public Task RemoveBucket(string bucketIdentifier);

    /// <summary>
    /// Проверить существует ли бакет 
    /// </summary>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    /// <returns>true если существует</returns>
    public Task<bool> BucketExist(string bucketIdentifier);

    /// <summary>
    /// Положить файл в бакет
    /// </summary>
    /// <param name="fileStream">Файл в виде <see cref="Stream"/></param>
    /// <param name="fileIdentifier">уникальный идентификатор файла</param>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    public Task PutFileInBucket(Stream fileStream, string fileIdentifier, string bucketIdentifier);

    /// <summary>
    /// Удалить файл из бакета
    /// </summary>
    /// <param name="fileIdentifier">уникальный идентификатор файла</param>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    public Task RemoveFileFromBucket(string fileIdentifier, string bucketIdentifier);
    
    /// <summary>
    /// Получить файл из бакета
    /// </summary>
    /// <param name="fileIdentifier">уникальный идентификатор файла</param>
    /// <param name="bucketIdentifier">уникальный идентификатор бакета</param>
    /// <returns>Файл в виде <see cref="Stream"/> или null если бакет или файл не найден. </returns>
    public Task<Stream?> GetFileFromBucket(string fileIdentifier, string bucketIdentifier);
}