using DotNetflix.Abstractions;
using FluentValidation;
using MediatR;

namespace DotNetflix.Admin.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse, string>> 
    where TRequest : notnull
{

    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<Result<TResponse, string>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse, string>> next, CancellationToken cancellationToken)
    {
        var validationResults = _validators
            .Select(async v => await v.ValidateAsync(request, cancellationToken));

        var result = (await Task.WhenAll(validationResults))
            .Where(v => !v.IsValid)
            .SelectMany(v => v.Errors)
            .Where(v => v != null)
            .Select(v => v.ToString())
            .ToList();

        if (result.Count == 0) return await next();
        return result.Aggregate((firstFailure, secondFailure) => $"{firstFailure} {secondFailure}");;
    }
}