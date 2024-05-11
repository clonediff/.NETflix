namespace Contracts.Shared;

public record GrpcSynchronizationMessage<TContent>(SupportChatMessageDto<TContent> Dto);