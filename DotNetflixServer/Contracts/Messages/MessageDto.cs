namespace Contracts.Messages;

public record MessageDto(string Message, string SenderName, DateTime SendingDate, bool BelongsToSender);