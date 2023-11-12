using Domain.Entities;
using DotNetflix.Application.Features.UserChat.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.UserChat.Commands.PutMessage;

internal class PutMessageCommandHandler : ICommandHandler<PutMessageCommand>
{
    private readonly DbContext _dbContext;

    public PutMessageCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(PutMessageCommand request, CancellationToken cancellationToken)
    {
        var userChatMessage = request.ToUserChatMessage();

        _dbContext.Set<UserChatMessage>().Add(userChatMessage);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}