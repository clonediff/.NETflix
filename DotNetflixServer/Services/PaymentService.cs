using System.Text.RegularExpressions;
using Contracts;
using Services.Abstractions;

namespace Services;

public class PaymentService : IPaymentService
{
    static bool ValidateCredentialsFormat(CardDataDto cardCredentials)
    {
        return Regex.IsMatch(cardCredentials.CardNumber, @"\d\d*") &&
               cardCredentials.CVV_CVC is >= 100 and <= 999;
    }

    public bool PayByCard(CardDataDto cardCredentials, decimal amount)
    {
        return ValidateCredentialsFormat(cardCredentials);
    }
}
