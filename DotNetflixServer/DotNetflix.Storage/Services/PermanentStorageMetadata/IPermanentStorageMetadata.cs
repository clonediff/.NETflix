using DotNetflix.Storage.Services.PermanentStorageMetadata.Models;

namespace DotNetflix.Storage.Services.PermanentStorageMetadata;

/// <summary>
/// Сервис с круд операциями к методанным в постоянном хранилище
/// </summary>
/// <typeparam name="TEntity">модель сущности</typeparam>
public interface IPermanentStorageMetadata<TEntity> where TEntity : IMongoDbEntity
{
	/// <summary>
	/// Получить сущность
	/// </summary>
	/// <param name="movieId">movieId</param>
	public Task<IEnumerable<TEntity>> GetByMovieIdAsync(int movieId);

	/// <summary>
	/// Вставить сушность
	/// </summary>
	/// <param name="entity">новая сущность</param>
	public Task InsertAsync(TEntity entity);

	/// <summary>
	/// Обновить сущность
	/// </summary>
	/// <param name="entity">обновленная сущность</param>
	public Task UpdateAsync(TEntity entity);

	/// <summary>
	/// Удалить сущности
	/// </summary>
	/// <param name="movieId">id</param>
	public Task DeleteByMovieIdAsync(int movieId);

	/// <summary>
	/// Удалить сущность
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>>
	public Task DeleteAsync(Guid id);
}