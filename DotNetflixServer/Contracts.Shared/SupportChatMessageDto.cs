namespace Contracts.Shared;

public record SupportChatMessageDto<TMessage>(
    string RoomId, 
    SupportChatMessageType MessageType,
    TMessage Content, 
    string SenderName, 
    DateTime SendingDate,
    bool BelongsToSender
) : MessageDto<TMessage>(Content, SenderName, SendingDate, BelongsToSender);

public enum SupportChatMessageType
{
    Text,
    File
}
