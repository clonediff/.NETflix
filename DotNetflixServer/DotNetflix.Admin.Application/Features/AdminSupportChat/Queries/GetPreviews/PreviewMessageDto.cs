namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;

public record PreviewMessageDto(string RoomId, string UserName, string LatestMessage, int TotalUnReadMessages);
