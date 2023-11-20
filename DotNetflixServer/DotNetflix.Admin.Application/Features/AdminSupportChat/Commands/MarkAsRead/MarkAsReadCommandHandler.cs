using DataAccess;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Commands.MarkAsRead;

internal class MarkAsReadCommandHandler : ICommandHandler<MarkAsReadCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public MarkAsReadCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
    {
        await _dbContext.Messages
            .Where(x => x.UserId == request.RoomId && !x.IsRead)
            .ExecuteUpdateAsync(x => x
                .SetProperty(m => m.IsRead, true), cancellationToken: cancellationToken);
    }
}
