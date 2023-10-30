using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.UserChat.Queries.GetAllMessages;

public record GetAllMessagesQuery : IQuery<IEnumerable<GetAllMessagesDto>>;