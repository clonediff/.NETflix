namespace Contracts.Shared;

public record MessageDto(string RoomId, string Message, string SenderName, DateTime SendingDate, bool BelongsToSender);
