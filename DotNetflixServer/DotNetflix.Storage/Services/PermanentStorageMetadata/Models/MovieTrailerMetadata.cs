namespace DotNetflix.Storage.Services.PermanentStorageMetadata.Models;

public class MovieTrailerMetadata : IMongoDbEntity
{
	public required Guid Id { get; set; }
	public required string Name { get; set; }
	public required string FileName { get; set; }
	public required DateTime Date { get; set; }
	public required string Language { get; set; }
	public required string Resolution { get; set; }
	public required int MovieId { get; set; }
}