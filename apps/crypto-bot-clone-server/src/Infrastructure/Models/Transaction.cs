using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CryptoBotClone.Core.Enums;

namespace CryptoBotClone.Infrastructure.Models;

[Table("Transactions")]
public class TransactionDbModel
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Currency { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Receiver { get; set; }

    [StringLength(1000)]
    public string? Sender { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime? TransactionDate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
