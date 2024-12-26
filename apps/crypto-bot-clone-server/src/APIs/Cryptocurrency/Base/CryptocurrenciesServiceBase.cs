using CryptoBotClone.APIs;
using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.APIs.Errors;
using CryptoBotClone.APIs.Extensions;
using CryptoBotClone.Infrastructure;
using CryptoBotClone.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoBotClone.APIs;

public abstract class CryptocurrenciesServiceBase : ICryptocurrenciesService
{
    protected readonly CryptoBotCloneDbContext _context;

    public CryptocurrenciesServiceBase(CryptoBotCloneDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Cryptocurrency
    /// </summary>
    public async Task<Cryptocurrency> CreateCryptocurrency(CryptocurrencyCreateInput createDto)
    {
        var cryptocurrency = new CryptocurrencyDbModel
        {
            Address = createDto.Address,
            CreatedAt = createDto.CreatedAt,
            Name = createDto.Name,
            SymbolField = createDto.SymbolField,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            cryptocurrency.Id = createDto.Id;
        }

        _context.Cryptocurrencies.Add(cryptocurrency);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CryptocurrencyDbModel>(cryptocurrency.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Cryptocurrency
    /// </summary>
    public async Task DeleteCryptocurrency(CryptocurrencyWhereUniqueInput uniqueId)
    {
        var cryptocurrency = await _context.Cryptocurrencies.FindAsync(uniqueId.Id);
        if (cryptocurrency == null)
        {
            throw new NotFoundException();
        }

        _context.Cryptocurrencies.Remove(cryptocurrency);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Cryptocurrencies
    /// </summary>
    public async Task<List<Cryptocurrency>> Cryptocurrencies(
        CryptocurrencyFindManyArgs findManyArgs
    )
    {
        var cryptocurrencies = await _context
            .Cryptocurrencies.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return cryptocurrencies.ConvertAll(cryptocurrency => cryptocurrency.ToDto());
    }

    /// <summary>
    /// Meta data about Cryptocurrency records
    /// </summary>
    public async Task<MetadataDto> CryptocurrenciesMeta(CryptocurrencyFindManyArgs findManyArgs)
    {
        var count = await _context.Cryptocurrencies.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Cryptocurrency
    /// </summary>
    public async Task<Cryptocurrency> Cryptocurrency(CryptocurrencyWhereUniqueInput uniqueId)
    {
        var cryptocurrencies = await this.Cryptocurrencies(
            new CryptocurrencyFindManyArgs
            {
                Where = new CryptocurrencyWhereInput { Id = uniqueId.Id }
            }
        );
        var cryptocurrency = cryptocurrencies.FirstOrDefault();
        if (cryptocurrency == null)
        {
            throw new NotFoundException();
        }

        return cryptocurrency;
    }

    /// <summary>
    /// Update one Cryptocurrency
    /// </summary>
    public async Task UpdateCryptocurrency(
        CryptocurrencyWhereUniqueInput uniqueId,
        CryptocurrencyUpdateInput updateDto
    )
    {
        var cryptocurrency = updateDto.ToModel(uniqueId);

        _context.Entry(cryptocurrency).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Cryptocurrencies.Any(e => e.Id == cryptocurrency.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
