using DtoLibrary;

namespace Services.PaymentService;

public interface IPaymentService
{
    bool PayByCard(CardDataDto cardCredentials, decimal amount);
}
