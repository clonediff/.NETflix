using Contracts.Shared;
using DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

namespace DotNetflix.Application.Features.UserChat.Mapping;

public static class GetAllMessagesDtoToMessageDto
{
    public static MessageDtoBase ToMessageDtoBase(this GetAllMessagesDto dto, string userId)
    {
        return MessageDtoFactory.Create(
            dto.Message,
            dto.SenderName,
            dto.SendingDate,
            dto.UserId == userId
        );
    }
}