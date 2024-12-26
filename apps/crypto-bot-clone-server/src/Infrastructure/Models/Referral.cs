using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoBotClone.Infrastructure.Models;

[Table("Referrals")]
public class ReferralDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Referee { get; set; }

    [StringLength(1000)]
    public string? Referrer { get; set; }

    [Range(-999999999, 999999999)]
    public double? Reward { get; set; }

    public DateTime? StartDate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
