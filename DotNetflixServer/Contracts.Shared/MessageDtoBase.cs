namespace Contracts.Shared;

public record MessageDtoBase(string SenderName, DateTime SendingDate, bool BelongsToSender);