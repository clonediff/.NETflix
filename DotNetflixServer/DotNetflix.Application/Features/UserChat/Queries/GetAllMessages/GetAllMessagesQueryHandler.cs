﻿using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Features.UserChat.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

internal class GetAllMessagesQueryHandler : IQueryHandler<GetAllMessagesQuery, IOrderedEnumerable<GetAllMessagesDto>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllMessagesQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IOrderedEnumerable<GetAllMessagesDto>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dbContext.UserChatMessages
            .AsNoTracking()
            .Include(m => m.User)
            .Select(m => m.ToGetAllMessagesDto())
            .AsEnumerable()
            .OrderBy(m => m.SendingDate)
        );
    }
}