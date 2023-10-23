namespace DotNetflix.Admin.Application.Features.Films.Mapping;

public static class DtosToEntities
{
    public static List<TOut> ToEntities<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> transformer)
    {
        return source
            .Select(transformer)
            .ToList();
    }
}