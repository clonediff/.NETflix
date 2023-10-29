using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;

public record GetPreviewsQuery(int Page, int PageSize) : IQuery<PaginationDataDto<PreviewMessageDto>>;