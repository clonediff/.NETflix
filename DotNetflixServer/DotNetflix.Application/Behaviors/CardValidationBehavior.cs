using System.Text.RegularExpressions;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using MediatR;

namespace DotNetflix.Application.Behaviors;

public class CardValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IHasCardValidation 
    where TResponse : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!Regex.IsMatch(request.CardDataDto.CardNumber, @"\d*\d*", RegexOptions.None, TimeSpan.FromSeconds(5))
            || request.CardDataDto.CVV_CVC is < 100 or > 999 || request.CardDataDto.ExpirationDate < DateTime.Now)
        {
            return (new Result<int, string>("Введены некорректные реквизиты к оплате.") as TResponse)!;
        }

        return await next();
    }
}