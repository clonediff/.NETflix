namespace Contracts.Shared;

public record SupportChatMessage(
    string Content, 
    DateTime SendingDate, 
    bool IsReadByAdmin, 
    bool IsFromAdmin, 
    string RoomId, 
    string UniqueKey
);