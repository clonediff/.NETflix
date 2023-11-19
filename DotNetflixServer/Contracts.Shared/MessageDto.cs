namespace Contracts.Shared;

public record MessageDto(string Message, string SenderName, DateTime SendingDate, bool BelongsToSender);
