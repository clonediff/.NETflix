using DotNetflix.Abstractions;
using FluentValidation;
using MediatR;

namespace DotNetflix.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse, IEnumerable<string>>> 
    where TRequest : notnull
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<Result<TResponse, IEnumerable<string>>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse, IEnumerable<string>>> next, CancellationToken cancellationToken)
    {
        var validationResults = _validators
            .Select(async v => await v.ValidateAsync(request, cancellationToken));
        
        var results = (await Task.WhenAll(validationResults))
            .Where(v => !v.IsValid)
            .SelectMany(v => v.Errors)
            .Where(v => v != null)
            .Select(v => v.ToString())
            .ToList();
        
        if (results.Any())
        {
            return results;
        }

        return await next();
    }
}