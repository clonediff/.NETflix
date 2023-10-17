using DataAccess;
using Domain.Entities;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.AddSubscription;

internal class AddSubscriptionCommandHandler : ICommandHandler<AddSubscriptionCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public AddSubscriptionCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Name = request.Dto.Name,
            PeriodInDays = request.Dto.PeriodInDays,
            Cost = request.Dto.Cost,
            IsAvailable = false
        };

        _dbContext.Subscriptions.Add(subscription);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}