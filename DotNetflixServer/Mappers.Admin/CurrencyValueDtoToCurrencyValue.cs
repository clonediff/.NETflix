using Contracts.Admin.Films;
using Domain.Entities;

namespace Mappers.Admin;

public static class CurrencyValueDtoToCurrencyValue
{
    public static CurrencyValue? ToCurrencyValue(this CurrencyValueDto dto)
    {
        return dto.Currency is null && dto.Value is null
            ? null
            : new CurrencyValue
            {
                Id = dto.Id,
                Currency = dto.Currency!,
                Value = dto.Value!.Value
            };
    }
}