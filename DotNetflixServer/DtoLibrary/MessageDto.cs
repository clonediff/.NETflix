namespace DtoLibrary;

public record MessageDto(string Message, string SenderName, DateTime SendingDate, bool BelongsToSender);