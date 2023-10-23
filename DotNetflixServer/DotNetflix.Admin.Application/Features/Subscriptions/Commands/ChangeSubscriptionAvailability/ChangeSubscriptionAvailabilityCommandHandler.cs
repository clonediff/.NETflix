using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;

internal class ChangeSubscriptionAvailabilityCommandHandler : ICommandHandler<ChangeSubscriptionAvailabilityCommand, Result<int, string>>
{
    private readonly ApplicationDBContext _dbContext;

    public ChangeSubscriptionAvailabilityCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, string>> Handle(ChangeSubscriptionAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (subscription is null)
            return "Не удалось найти подписку";

        subscription.IsAvailable = request.IsAvailable;

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}