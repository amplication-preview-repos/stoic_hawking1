using CryptoBotClone.Infrastructure;

namespace CryptoBotClone.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(CryptoBotCloneDbContext context)
        : base(context) { }
}
