using CryptoBotClone.Infrastructure;

namespace CryptoBotClone.APIs;

public class ReferralsService : ReferralsServiceBase
{
    public ReferralsService(CryptoBotCloneDbContext context)
        : base(context) { }
}
