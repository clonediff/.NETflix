namespace Contracts.Messages;

public record UserMessageDto(string Message, string SenderName, DateTime SendingDate, string UserId);