using DataAccess;
using Domain.Entities;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Features.UserChat.Mapping;

namespace DotNetflix.Application.Features.UserChat.Commands.PutMessage;

internal class PutMessageCommandHandler : ICommandHandler<PutMessageCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public PutMessageCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(PutMessageCommand request, CancellationToken cancellationToken)
    {
        var userChatMessage = request.ToUserChatMessage();

        _dbContext.UserChatMessages.Add(userChatMessage);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}