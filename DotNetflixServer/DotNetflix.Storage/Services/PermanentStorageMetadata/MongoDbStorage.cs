using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;
using MongoDB.Driver;

namespace DotNetflix.Storage.Services.PermanentStorageMetadata;

public class MongoDbStorage<TEntity> : IPermanentStorageMetadata<TEntity> where TEntity : IMongoDbEntity
{
	private readonly IMongoCollection<TEntity> _mongoCollection;

	public MongoDbStorage(IMongoCollection<TEntity> mongoCollection)
	{
		_mongoCollection = mongoCollection;
	}
	
	public async Task<IEnumerable<TEntity>> GetByMovieIdAsync(int movieId) => 
		await _mongoCollection.Find(x => x.MovieId == movieId).ToListAsync();
	
	public async Task InsertAsync(TEntity entity) =>
		await _mongoCollection.InsertOneAsync(entity);

	public async Task UpdateAsync(TEntity entity) =>
		await _mongoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

	public async Task DeleteByMovieIdAsync(int movieId) =>
		await _mongoCollection.DeleteManyAsync(x => x.MovieId == movieId);

	public async Task DeleteAsync(Guid id) =>
		await _mongoCollection.DeleteOneAsync(x => x.Id == id);
}