namespace Contracts.Shared;

public record MessageDto(object Message, string SenderName, DateTime SendingDate, bool BelongsToSender);
