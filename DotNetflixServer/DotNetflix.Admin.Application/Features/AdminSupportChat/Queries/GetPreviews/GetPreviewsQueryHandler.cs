using System.Text.RegularExpressions;
using DataAccess;
using Domain.Extensions;
using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;

internal partial class GetPreviewsQueryHandler : IQueryHandler<GetPreviewsQuery, PaginationDataDto<PreviewMessageDto>>
{
    private readonly ApplicationDBContext _dbContext;
    
    private const string AdminName = "Администратор";

    public GetPreviewsQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationDataDto<PreviewMessageDto>> Handle(GetPreviewsQuery request, CancellationToken cancellationToken)
    {
        var rooms = _dbContext.Messages
            .Include(x => x.User)
            .GroupBy(x => x.User)
            .Select(x =>
                new
                {
                    RoomId = x.Key.Id,
                    LatestMessage = x.OrderByDescending(y => y.SendingDate).First(),
                    UnreadMessages = x.Count(y => !y.IsRead)
                });
        
        var totalRoomsCount = await rooms.CountAsync(cancellationToken: cancellationToken); 
        
        var resultRooms = rooms 
            .Paginate(request.Page, request.PageSize)
            .AsEnumerable()
            .Select(x =>
                new PreviewMessageDto(x.RoomId, x.LatestMessage.IsFromAdmin ? AdminName : x.LatestMessage.User.UserName!,
                    FileRegex().IsMatch(x.LatestMessage.Content) ? "файл" : x.LatestMessage.Content, x.UnreadMessages))
            .ToList();
        return new PaginationDataDto<PreviewMessageDto>(resultRooms, totalRoomsCount);
    }

    [GeneratedRegex("file_.+_.+_.+\\/.+")]
    private static partial Regex FileRegex();
}
