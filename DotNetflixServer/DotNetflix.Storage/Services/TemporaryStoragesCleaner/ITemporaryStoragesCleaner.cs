namespace DotNetflix.Storage.Services.TemporaryStoragesCleaner;

public interface ITemporaryStoragesCleaner
{
    Task<bool> ClearStorages(string metadataKey, string transactionKey);
}