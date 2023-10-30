namespace DotNetflix.Admin.Application.Shared;

public record PaginationDataDto<T>(IEnumerable<T> Data, int Count);