using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.UserChat.Commands.PutMessage;

public record PutMessageCommand(string Message, DateTime SendingDate, string UserId) : ICommand;