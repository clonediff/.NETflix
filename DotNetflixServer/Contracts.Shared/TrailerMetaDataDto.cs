namespace Contracts.Shared;

public record TrailerMetaDataDto(Guid? Id, string Name, string FileName, DateTime Date, string Language, string Resolution);