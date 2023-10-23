using Contracts.Shared;

namespace Services.Shared.PaymentService;

public interface IPaymentService
{
    bool PayByCard(CardDataDto cardCredentials, decimal amount);
}
