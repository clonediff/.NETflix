using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;

public record GetPreviewsQuery(int Page, int PageSize) : IQuery<PaginationDataDto<PreviewMessageDto>>;