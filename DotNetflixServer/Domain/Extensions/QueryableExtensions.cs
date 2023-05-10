namespace Domain.Extensions;

public static class QueryableExtensions
{
    /// <summary>
    /// returns specified slice of sequence
    /// </summary>
    /// <param name="source">The source query</param>
    /// <param name="pageNumber">The number of page</param>
    /// <param name="pageSize">The page size</param>
    /// <typeparam name="TEntity">The type of entity being queried</typeparam>
    /// <returns></returns>
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> source, int pageNumber, int pageSize)
    {
        return source
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);
    }
}