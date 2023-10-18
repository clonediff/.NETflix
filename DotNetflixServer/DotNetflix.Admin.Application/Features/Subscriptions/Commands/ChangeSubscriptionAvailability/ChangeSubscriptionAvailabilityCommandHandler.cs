using DataAccess;
using Domain.Exceptions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;

internal class ChangeSubscriptionAvailabilityCommandHandler : ICommandHandler<ChangeSubscriptionAvailabilityCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public ChangeSubscriptionAvailabilityCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(ChangeSubscriptionAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        subscription.IsAvailable = request.IsAvailable;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}