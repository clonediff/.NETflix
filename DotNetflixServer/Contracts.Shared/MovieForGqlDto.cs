namespace Contracts.Shared;

public record MovieForGqlDto<T>(T? Movie, string? Error);