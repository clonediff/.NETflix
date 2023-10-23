namespace DotNetflix.Admin.Application.Features.Films.Shared;

public record FeesDto(int Id, CurrencyValueDto? FeesWorld, CurrencyValueDto? FeesRussia, CurrencyValueDto? FeesUsa);