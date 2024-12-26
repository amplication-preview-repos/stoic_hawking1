using CryptoBotClone.Core.Enums;

namespace CryptoBotClone.APIs.Dtos;

public class TransactionWhereInput
{
    public double? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Currency { get; set; }

    public string? Id { get; set; }

    public string? Receiver { get; set; }

    public string? Sender { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime? TransactionDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
