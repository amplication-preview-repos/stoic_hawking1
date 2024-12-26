using CryptoBotClone.Infrastructure;

namespace CryptoBotClone.APIs;

public class CryptocurrenciesService : CryptocurrenciesServiceBase
{
    public CryptocurrenciesService(CryptoBotCloneDbContext context)
        : base(context) { }
}
