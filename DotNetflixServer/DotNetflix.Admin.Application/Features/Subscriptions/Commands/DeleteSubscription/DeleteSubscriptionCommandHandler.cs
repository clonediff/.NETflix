using DataAccess;
using Domain.Exceptions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.DeleteSubscription;

internal class DeleteSubscriptionCommandHandler : ICommandHandler<DeleteSubscriptionCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public DeleteSubscriptionCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.SubscriptionId, cancellationToken);

        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        if (_dbContext.UserSubscriptions.Any(us => us.SubscriptionId == request.SubscriptionId))
            throw new IncorrectOperationException("Не удалось удалить подписку");

        _dbContext.Subscriptions.Remove(subscription);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}