using DataAccess;
using Domain.Entities;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateSubscription;

internal class UpdateSubscriptionCommandHandler : ICommandHandler<UpdateSubscriptionCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public UpdateSubscriptionCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Subscriptions.Update(new Subscription
        {
            Id = request.Id,
            Cost = request.Cost,
            Name = request.Name,
            PeriodInDays = request.PeriodInDays
        });

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}