using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateSubscription;

internal class UpdateSubscriptionCommandHandler : ICommandHandler<UpdateSubscriptionCommand>
{
    private readonly DbContext _dbContext;

    public UpdateSubscriptionCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Set<Subscription>().Update(new Subscription
        {
            Id = request.Id,
            Cost = request.Cost,
            Name = request.Name,
            PeriodInDays = request.PeriodInDays
        });

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}