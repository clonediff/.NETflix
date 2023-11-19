namespace Contracts.Shared;

public record SupportChatMessageDto(string RoomId, string Message, string SenderName, DateTime SendingDate,
    bool BelongsToSender) : MessageDto(Message, SenderName, SendingDate, BelongsToSender);
