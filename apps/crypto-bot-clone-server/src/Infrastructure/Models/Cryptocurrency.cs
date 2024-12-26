using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoBotClone.Infrastructure.Models;

[Table("Cryptocurrencies")]
public class CryptocurrencyDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? SymbolField { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
