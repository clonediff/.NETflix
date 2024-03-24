using Grpc.Core;

namespace DotNetflix.Payment.Services;

public class PaymentService : Payment.PaymentService.PaymentServiceBase
{
    public override Task<Response> Pay(CardData request, ServerCallContext context)
    {
        return AsyncCardOperation(context.CancellationToken);
    }

    public override Task<Response> Refund(CardData request, ServerCallContext context)
    {
        return AsyncCardOperation(context.CancellationToken);
    }

    private static async Task<Response> AsyncCardOperation(CancellationToken cancellationToken)
    {
        await Task.Delay(2000, cancellationToken);
        
        return new Response
        {
            Success = true
        };
    }
}