
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Commands.MarkAsRead;

public record MarkAsReadCommand(string RoomId) : ICommand;