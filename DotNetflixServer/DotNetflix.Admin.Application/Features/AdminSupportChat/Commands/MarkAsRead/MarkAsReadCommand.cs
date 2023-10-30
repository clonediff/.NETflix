using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Commands.MarkAsRead;

public record MarkAsReadCommand(string RoomId) : ICommand;