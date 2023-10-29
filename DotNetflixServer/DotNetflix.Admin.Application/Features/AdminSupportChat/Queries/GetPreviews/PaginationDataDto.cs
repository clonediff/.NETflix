namespace DotNetflix.Admin.Application.Features.AdminSupportChat.Queries.GetPreviews;

public record PaginationDataDto<T>(IEnumerable<T> Data, int Count);