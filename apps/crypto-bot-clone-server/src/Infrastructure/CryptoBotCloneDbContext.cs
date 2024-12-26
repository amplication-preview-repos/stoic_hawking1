using CryptoBotClone.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoBotClone.Infrastructure;

public class CryptoBotCloneDbContext : DbContext
{
    public CryptoBotCloneDbContext(DbContextOptions<CryptoBotCloneDbContext> options)
        : base(options) { }

    public DbSet<CryptocurrencyDbModel> Cryptocurrencies { get; set; }

    public DbSet<TransactionDbModel> Transactions { get; set; }

    public DbSet<ReferralDbModel> Referrals { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
