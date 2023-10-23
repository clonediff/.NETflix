namespace DotNetflix.Admin.Application.Shared;

public record EnumDto<TKey>(TKey Id, string Name);