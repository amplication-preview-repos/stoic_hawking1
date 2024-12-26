using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;

namespace CryptoBotClone.APIs;

public interface ICryptocurrenciesService
{
    /// <summary>
    /// Create one Cryptocurrency
    /// </summary>
    public Task<Cryptocurrency> CreateCryptocurrency(CryptocurrencyCreateInput cryptocurrency);

    /// <summary>
    /// Delete one Cryptocurrency
    /// </summary>
    public Task DeleteCryptocurrency(CryptocurrencyWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Cryptocurrencies
    /// </summary>
    public Task<List<Cryptocurrency>> Cryptocurrencies(CryptocurrencyFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Cryptocurrency records
    /// </summary>
    public Task<MetadataDto> CryptocurrenciesMeta(CryptocurrencyFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Cryptocurrency
    /// </summary>
    public Task<Cryptocurrency> Cryptocurrency(CryptocurrencyWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Cryptocurrency
    /// </summary>
    public Task UpdateCryptocurrency(
        CryptocurrencyWhereUniqueInput uniqueId,
        CryptocurrencyUpdateInput updateDto
    );
}
