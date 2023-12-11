namespace DotNetflix.Storage.Services.StoragesSynchronization;

public interface IStoragesSynchronizationService
{
    Task<bool> SynchronizeStorages(string movieId, string transactionKey);
}