using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;

namespace CryptoBotClone.APIs;

public interface IReferralsService
{
    /// <summary>
    /// Create one Referral
    /// </summary>
    public Task<Referral> CreateReferral(ReferralCreateInput referral);

    /// <summary>
    /// Delete one Referral
    /// </summary>
    public Task DeleteReferral(ReferralWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Referrals
    /// </summary>
    public Task<List<Referral>> Referrals(ReferralFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Referral records
    /// </summary>
    public Task<MetadataDto> ReferralsMeta(ReferralFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Referral
    /// </summary>
    public Task<Referral> Referral(ReferralWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Referral
    /// </summary>
    public Task UpdateReferral(ReferralWhereUniqueInput uniqueId, ReferralUpdateInput updateDto);
}
