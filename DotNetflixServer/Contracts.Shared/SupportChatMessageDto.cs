namespace Contracts.Shared;

public record SupportChatMessageDto<TContent>(
    string RoomId, 
    SupportChatMessageType MessageType,
    TContent Content, 
    string SenderName, 
    DateTime SendingDate,
    bool BelongsToSender
) : MessageDto<TContent>(Content, SenderName, SendingDate, BelongsToSender);

public enum SupportChatMessageType
{
    Text,
    File
}
