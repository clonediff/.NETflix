namespace Contracts.Messages;

public record SendMessageDto(string Message, string? RoomId);