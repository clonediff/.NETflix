using DotNetflix.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Shared.Mapping;

public static class IdentityResultToResult
{
    public static Result<string, string> ToResult(this IdentityResult result, string successString)
    {
        return result.Succeeded
            ? new Result<string, string>(success: successString)
            : new Result<string, string>(failure: string.Join('\n',
                result.Errors.Select(x => $"{x.Code}:{x.Description}")));
    }
}
