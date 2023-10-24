using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DotNetflix.Application.Behaviors;

public class CodeValidationBehavior<TRequest, TSuccess> : IPipelineBehavior<TRequest, Result<TSuccess, string>>
    where TRequest : IHasCodeValidation
{
    private readonly IMemoryCache _memoryCache;

    public CodeValidationBehavior(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<Result<TSuccess, string>> Handle(TRequest request, RequestHandlerDelegate<Result<TSuccess, string>> next, CancellationToken cancellationToken)
    {
        if (!_memoryCache.TryGetValue<string>(request.Key, out var savedCode) || savedCode != request.Code)
        {
            return "Код не совпадает или устарел";
        }

        return await next();
    }
}