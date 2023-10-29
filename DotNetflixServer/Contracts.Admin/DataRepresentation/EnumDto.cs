namespace Contracts.Admin.DataRepresentation;

public record EnumDto<TKey>(TKey Id, string Name);