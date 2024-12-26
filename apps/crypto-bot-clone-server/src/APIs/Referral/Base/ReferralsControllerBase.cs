using CryptoBotClone.APIs;
using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ReferralsControllerBase : ControllerBase
{
    protected readonly IReferralsService _service;

    public ReferralsControllerBase(IReferralsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Referral
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Referral>> CreateReferral(ReferralCreateInput input)
    {
        var referral = await _service.CreateReferral(input);

        return CreatedAtAction(nameof(Referral), new { id = referral.Id }, referral);
    }

    /// <summary>
    /// Delete one Referral
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteReferral([FromRoute()] ReferralWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteReferral(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Referrals
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Referral>>> Referrals(
        [FromQuery()] ReferralFindManyArgs filter
    )
    {
        return Ok(await _service.Referrals(filter));
    }

    /// <summary>
    /// Meta data about Referral records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ReferralsMeta(
        [FromQuery()] ReferralFindManyArgs filter
    )
    {
        return Ok(await _service.ReferralsMeta(filter));
    }

    /// <summary>
    /// Get one Referral
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Referral>> Referral(
        [FromRoute()] ReferralWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Referral(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Referral
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateReferral(
        [FromRoute()] ReferralWhereUniqueInput uniqueId,
        [FromQuery()] ReferralUpdateInput referralUpdateDto
    )
    {
        try
        {
            await _service.UpdateReferral(uniqueId, referralUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
