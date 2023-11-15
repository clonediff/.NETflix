namespace DotNetflixAPI.Dto;

public record SendMessageDto<TMessage>(TMessage Message, string? RoomId);