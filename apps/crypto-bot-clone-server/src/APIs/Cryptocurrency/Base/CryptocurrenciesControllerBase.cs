using CryptoBotClone.APIs;
using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CryptocurrenciesControllerBase : ControllerBase
{
    protected readonly ICryptocurrenciesService _service;

    public CryptocurrenciesControllerBase(ICryptocurrenciesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Cryptocurrency
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Cryptocurrency>> CreateCryptocurrency(
        CryptocurrencyCreateInput input
    )
    {
        var cryptocurrency = await _service.CreateCryptocurrency(input);

        return CreatedAtAction(
            nameof(Cryptocurrency),
            new { id = cryptocurrency.Id },
            cryptocurrency
        );
    }

    /// <summary>
    /// Delete one Cryptocurrency
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCryptocurrency(
        [FromRoute()] CryptocurrencyWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCryptocurrency(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Cryptocurrencies
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Cryptocurrency>>> Cryptocurrencies(
        [FromQuery()] CryptocurrencyFindManyArgs filter
    )
    {
        return Ok(await _service.Cryptocurrencies(filter));
    }

    /// <summary>
    /// Meta data about Cryptocurrency records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CryptocurrenciesMeta(
        [FromQuery()] CryptocurrencyFindManyArgs filter
    )
    {
        return Ok(await _service.CryptocurrenciesMeta(filter));
    }

    /// <summary>
    /// Get one Cryptocurrency
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Cryptocurrency>> Cryptocurrency(
        [FromRoute()] CryptocurrencyWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Cryptocurrency(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Cryptocurrency
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCryptocurrency(
        [FromRoute()] CryptocurrencyWhereUniqueInput uniqueId,
        [FromQuery()] CryptocurrencyUpdateInput cryptocurrencyUpdateDto
    )
    {
        try
        {
            await _service.UpdateCryptocurrency(uniqueId, cryptocurrencyUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
