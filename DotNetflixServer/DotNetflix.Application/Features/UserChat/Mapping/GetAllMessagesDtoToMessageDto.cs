using Contracts.Shared;
using DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

namespace DotNetflix.Application.Features.UserChat.Mapping;

public static class GetAllMessagesDtoToMessageDto
{
    public static MessageDto<string> ToMessageDto(this GetAllMessagesDto dto, string userId)
    {
        return new MessageDto<string>(
            Message: dto.Message,
            SenderName: dto.SenderName,
            SendingDate: dto.SendingDate,
            BelongsToSender: dto.UserId == userId
        );
    }
}