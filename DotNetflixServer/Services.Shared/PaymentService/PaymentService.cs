using System.Text.RegularExpressions;
using Contracts.Shared;

namespace Services.Shared.PaymentService;

public class PaymentService : IPaymentService
{
    static bool ValidateCredentialsFormat(CardDataDto cardCredentials)
    {
        return Regex.IsMatch(cardCredentials.CardNumber, @"\d\d*", 
                   RegexOptions.None, TimeSpan.FromSeconds(5)) &&
               cardCredentials.CVV_CVC is >= 100 and <= 999;
    }

    public bool PayByCard(CardDataDto cardCredentials, decimal amount)
    {
        return ValidateCredentialsFormat(cardCredentials);
    }
}
