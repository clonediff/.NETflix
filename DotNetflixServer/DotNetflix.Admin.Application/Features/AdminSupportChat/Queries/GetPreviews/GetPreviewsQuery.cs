using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;

public record GetPreviewsQuery(int Page, int PageSize) : IQuery<PaginationDataDto<PreviewMessageDto>>;