namespace DotNetflix.Storage.Services.StoragesSynchronization;

public interface IStoragesSynchronizationService
{
    Task<bool> SynchronizeStorages(string metadataKey, string transactionKey);
}