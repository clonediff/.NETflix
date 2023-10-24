using System.Text.RegularExpressions;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using MediatR;

namespace DotNetflix.Application.Behaviors;

public class CardValidationBehavior<TRequest, TSuccess> : IPipelineBehavior<TRequest, Result<TSuccess, string>>
    where TRequest : IHasCardValidation 
{
    public async Task<Result<TSuccess, string>> Handle(TRequest request, RequestHandlerDelegate<Result<TSuccess, string>> next, CancellationToken cancellationToken)
    {
        if (!Regex.IsMatch(request.CardDataDto.CardNumber, @"\d*\d*", RegexOptions.None, TimeSpan.FromSeconds(5))
            || request.CardDataDto.CVV_CVC is < 100 or > 999 || request.CardDataDto.ExpirationDate < DateTime.Now)
        {
            return "Введены некорректные реквизиты к оплате.";
        }

        return await next();
    }
}