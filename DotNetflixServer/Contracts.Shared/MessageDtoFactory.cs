namespace Contracts.Shared;

public static class MessageDtoFactory
{
    public static MessageDto<TMessage> Create<TMessage>(TMessage message, string senderName, DateTime sendingDate, bool belongsToSender)
    {
        return new MessageDto<TMessage>(message, senderName, sendingDate, belongsToSender);
    }
}