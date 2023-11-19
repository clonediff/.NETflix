namespace Contracts.Shared;

public record MessageDto<TMessage>(TMessage Message, string SenderName, DateTime SendingDate, bool BelongsToSender) 
    : MessageDtoBase(SenderName, SendingDate, BelongsToSender);