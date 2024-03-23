using Grpc.Core;

namespace DotNetflix.Payment.Services;

public class PaymentService : Payment.PaymentService.PaymentServiceBase
{
    public override async Task<Response> Pay(CardData request, ServerCallContext context)
    {
        await Task.Delay(2000, context.CancellationToken);

        return new Response
        {
            Success = true
        };
    }

    public override async Task<Response> Refund(CardData request, ServerCallContext context)
    {
        await Task.Delay(2000, context.CancellationToken);
        
        return new Response
        {
            Success = true
        };
    }
}