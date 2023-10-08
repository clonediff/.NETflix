namespace Contracts.Admin.Messages;

public record PreviewMessageDto(string RoomId, string UserName, string LatestMessage, int TotalUnreadMessages);
