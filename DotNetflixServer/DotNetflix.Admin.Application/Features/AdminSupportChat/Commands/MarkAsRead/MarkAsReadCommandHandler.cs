using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Commands.MarkAsRead;

internal class MarkAsReadCommandHandler : ICommandHandler<MarkAsReadCommand>
{
    private readonly DbContext _dbContext;

    public MarkAsReadCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
    {
        await _dbContext.Set<Message>()
            .Where(x => x.UserId == request.RoomId)
            .ExecuteUpdateAsync(x => x
                .SetProperty(m => m.IsRead, true), cancellationToken: cancellationToken);
    }
}
