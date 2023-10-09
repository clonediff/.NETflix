using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Messages;

namespace Services.Admin.Abstractions;

public interface IAdminSupportChatService
{
    Task<PaginationDataDto<PreviewMessageDto>> GetPreviewsAsync(int page, int pageSize);

    Task MarkAsReadAsync(string roomId);
}
