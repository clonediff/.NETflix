using Contracts;

namespace Services.Abstractions;

public interface IPaymentService
{
    bool PayByCard(CardDataDto cardCredentials, decimal amount);
}
