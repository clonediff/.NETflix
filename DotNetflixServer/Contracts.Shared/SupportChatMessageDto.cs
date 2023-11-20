namespace Contracts.Shared;

public record SupportChatMessageDto<TMessage>(string RoomId, TMessage Message, string SenderName, DateTime SendingDate,
    bool BelongsToSender) : MessageDto<TMessage>(Message, SenderName, SendingDate, BelongsToSender);
