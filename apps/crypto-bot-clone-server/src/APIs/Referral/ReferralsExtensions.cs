using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.Infrastructure.Models;

namespace CryptoBotClone.APIs.Extensions;

public static class ReferralsExtensions
{
    public static Referral ToDto(this ReferralDbModel model)
    {
        return new Referral
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Referee = model.Referee,
            Referrer = model.Referrer,
            Reward = model.Reward,
            StartDate = model.StartDate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ReferralDbModel ToModel(
        this ReferralUpdateInput updateDto,
        ReferralWhereUniqueInput uniqueId
    )
    {
        var referral = new ReferralDbModel
        {
            Id = uniqueId.Id,
            Referee = updateDto.Referee,
            Referrer = updateDto.Referrer,
            Reward = updateDto.Reward,
            StartDate = updateDto.StartDate
        };

        if (updateDto.CreatedAt != null)
        {
            referral.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            referral.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return referral;
    }
}
