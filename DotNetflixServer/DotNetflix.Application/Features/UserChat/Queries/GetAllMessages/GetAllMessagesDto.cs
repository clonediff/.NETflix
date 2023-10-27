namespace DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

public record GetAllMessagesDto(string Message, string SenderName, DateTime SendingDate, string UserId);