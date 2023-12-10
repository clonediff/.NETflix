namespace DotNetflix.Storage.Services.PermanentStorageMetadata.Models;

public interface IMongoDbEntity
{
	public Guid Id { get; set; }
	public int MovieId { get; set; }
}