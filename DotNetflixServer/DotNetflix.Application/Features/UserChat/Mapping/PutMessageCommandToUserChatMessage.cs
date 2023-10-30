using Domain.Entities;
using DotNetflix.Application.Features.UserChat.Commands.PutMessage;

namespace DotNetflix.Application.Features.UserChat.Mapping;

public static class PutMessageCommandToUserChatMessage
{
    public static UserChatMessage ToUserChatMessage(this PutMessageCommand command)
    {
        return new UserChatMessage
        {
            Content = command.Message,
            SendingDate = command.SendingDate,
            UserId = command.UserId
        };
    }
}