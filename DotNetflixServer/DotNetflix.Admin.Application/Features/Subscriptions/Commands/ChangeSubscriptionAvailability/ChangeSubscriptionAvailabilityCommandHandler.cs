using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;

internal class ChangeSubscriptionAvailabilityCommandHandler : ICommandHandler<ChangeSubscriptionAvailabilityCommand, Result<int, string>>
{
    private readonly DbContext _dbContext;

    public ChangeSubscriptionAvailabilityCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, string>> Handle(ChangeSubscriptionAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Set<Subscription>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (subscription is null)
            return "Не удалось найти подписку";

        subscription.IsAvailable = request.IsAvailable;

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}