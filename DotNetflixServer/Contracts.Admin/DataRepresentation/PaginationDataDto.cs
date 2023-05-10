namespace Contracts.Admin.DataRepresentation;

public record PaginationDataDto<T>(IEnumerable<T> Data, int Count);