namespace DotNetflix.Storage.Services.PermanentStorageMetadata.Models;

public class MoviePosterMetadata : IMongoDbEntity
{
	public required Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Resolution { get; set; }
	public required int MovieId { get; set; }
}