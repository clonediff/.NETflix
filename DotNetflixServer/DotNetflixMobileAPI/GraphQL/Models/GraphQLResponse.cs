using DotNetflix.CQRS;

namespace DotNetflixMobileAPI.GraphQL.Models;

public record GraphQLResponse(bool HasError, string? Error = null)
{
    public static implicit operator GraphQLResponse(string error)
    {
        return new GraphQLResponse(true, error);
    }
}

public record GraphQLResponse<T>(bool HasError, T? Data, string? Error = null)
{
    public static implicit operator GraphQLResponse<T>(string error)
    {
        return new GraphQLResponse<T>(true, default, error);
    }

    public static implicit operator GraphQLResponse<T>(Result<T, string> result)
    {
        return result.Match(
            x => new GraphQLResponse<T>(false, x),
            x => new GraphQLResponse<T>(true, default, x)
        );
    }

    public static implicit operator GraphQLResponse<T>(T data)
    {
        return new GraphQLResponse<T>(false, data);
    }
}