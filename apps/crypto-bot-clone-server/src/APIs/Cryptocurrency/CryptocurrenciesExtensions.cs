using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.Infrastructure.Models;

namespace CryptoBotClone.APIs.Extensions;

public static class CryptocurrenciesExtensions
{
    public static Cryptocurrency ToDto(this CryptocurrencyDbModel model)
    {
        return new Cryptocurrency
        {
            Address = model.Address,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            SymbolField = model.SymbolField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CryptocurrencyDbModel ToModel(
        this CryptocurrencyUpdateInput updateDto,
        CryptocurrencyWhereUniqueInput uniqueId
    )
    {
        var cryptocurrency = new CryptocurrencyDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            Name = updateDto.Name,
            SymbolField = updateDto.SymbolField
        };

        if (updateDto.CreatedAt != null)
        {
            cryptocurrency.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            cryptocurrency.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return cryptocurrency;
    }
}
