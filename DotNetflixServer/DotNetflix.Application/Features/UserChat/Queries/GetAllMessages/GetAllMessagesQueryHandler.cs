using DataAccess;
using DotNetflix.Application.Features.UserChat.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

internal class GetAllMessagesQueryHandler : IQueryHandler<GetAllMessagesQuery, IEnumerable<GetAllMessagesDto>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllMessagesQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<GetAllMessagesDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dbContext.UserChatMessages
            .AsNoTracking()
            .Include(m => m.User)
            .OrderBy(m => m.SendingDate)
            .Select(m => m.ToGetAllMessagesDto())
            .AsEnumerable()
        );
    }
}