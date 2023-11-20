using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.DeleteSubscription;

internal class DeleteSubscriptionCommandHandler : ICommandHandler<DeleteSubscriptionCommand, Result<int, string>>
{
    private readonly DbContext _dbContext;

    public DeleteSubscriptionCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, string>> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Set<Subscription>().FirstOrDefaultAsync(x => x.Id == request.SubscriptionId, cancellationToken);

        if (subscription is null)
            return "Не удалось найти подписку";

        if (_dbContext.Set<UserSubscription>().Any(us => us.SubscriptionId == request.SubscriptionId))
            return "Не удалось удалить подписку";

        _dbContext.Set<Subscription>().Remove(subscription);

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}