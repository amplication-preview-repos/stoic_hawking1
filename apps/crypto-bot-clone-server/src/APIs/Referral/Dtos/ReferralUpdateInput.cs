namespace CryptoBotClone.APIs.Dtos;

public class ReferralUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Referee { get; set; }

    public string? Referrer { get; set; }

    public double? Reward { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
