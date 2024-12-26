using CryptoBotClone.APIs;
using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.APIs.Errors;
using CryptoBotClone.APIs.Extensions;
using CryptoBotClone.Infrastructure;
using CryptoBotClone.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoBotClone.APIs;

public abstract class ReferralsServiceBase : IReferralsService
{
    protected readonly CryptoBotCloneDbContext _context;

    public ReferralsServiceBase(CryptoBotCloneDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Referral
    /// </summary>
    public async Task<Referral> CreateReferral(ReferralCreateInput createDto)
    {
        var referral = new ReferralDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Referee = createDto.Referee,
            Referrer = createDto.Referrer,
            Reward = createDto.Reward,
            StartDate = createDto.StartDate,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            referral.Id = createDto.Id;
        }

        _context.Referrals.Add(referral);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ReferralDbModel>(referral.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Referral
    /// </summary>
    public async Task DeleteReferral(ReferralWhereUniqueInput uniqueId)
    {
        var referral = await _context.Referrals.FindAsync(uniqueId.Id);
        if (referral == null)
        {
            throw new NotFoundException();
        }

        _context.Referrals.Remove(referral);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Referrals
    /// </summary>
    public async Task<List<Referral>> Referrals(ReferralFindManyArgs findManyArgs)
    {
        var referrals = await _context
            .Referrals.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return referrals.ConvertAll(referral => referral.ToDto());
    }

    /// <summary>
    /// Meta data about Referral records
    /// </summary>
    public async Task<MetadataDto> ReferralsMeta(ReferralFindManyArgs findManyArgs)
    {
        var count = await _context.Referrals.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Referral
    /// </summary>
    public async Task<Referral> Referral(ReferralWhereUniqueInput uniqueId)
    {
        var referrals = await this.Referrals(
            new ReferralFindManyArgs { Where = new ReferralWhereInput { Id = uniqueId.Id } }
        );
        var referral = referrals.FirstOrDefault();
        if (referral == null)
        {
            throw new NotFoundException();
        }

        return referral;
    }

    /// <summary>
    /// Update one Referral
    /// </summary>
    public async Task UpdateReferral(
        ReferralWhereUniqueInput uniqueId,
        ReferralUpdateInput updateDto
    )
    {
        var referral = updateDto.ToModel(uniqueId);

        _context.Entry(referral).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Referrals.Any(e => e.Id == referral.Id))
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
