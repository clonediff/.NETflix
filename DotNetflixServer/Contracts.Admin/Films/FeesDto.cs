namespace Contracts.Admin.Films;

public record FeesDto(int Id, CurrencyValueDto? FeesWorld, CurrencyValueDto? FeesRussia, CurrencyValueDto? FeesUsa);