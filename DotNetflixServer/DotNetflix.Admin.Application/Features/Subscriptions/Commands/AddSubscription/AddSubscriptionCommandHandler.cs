using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.AddSubscription;

internal class AddSubscriptionCommandHandler : ICommandHandler<AddSubscriptionCommand>
{
    private readonly DbContext _dbContext;

    public AddSubscriptionCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Name = request.Name,
            PeriodInDays = request.PeriodInDays,
            Cost = request.Cost,
            IsAvailable = false
        };

        _dbContext.Set<Subscription>().Add(subscription);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}