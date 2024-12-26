using CryptoBotClone.Infrastructure;

namespace CryptoBotClone.APIs;

public class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(CryptoBotCloneDbContext context)
        : base(context) { }
}
