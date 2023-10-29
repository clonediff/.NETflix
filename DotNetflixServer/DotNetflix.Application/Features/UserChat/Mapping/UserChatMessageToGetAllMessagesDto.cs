using Domain.Entities;
using DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

namespace DotNetflix.Application.Features.UserChat.Mapping;

public static class UserChatMessageToGetAllMessagesDto
{
    public static GetAllMessagesDto ToGetAllMessagesDto(this UserChatMessage userChatMessage)
    {
        return new GetAllMessagesDto(
            Message: userChatMessage.Content,
            SenderName: userChatMessage.User.UserName!,
            SendingDate: userChatMessage.SendingDate,
            UserId: userChatMessage.UserId
        );
    }
}