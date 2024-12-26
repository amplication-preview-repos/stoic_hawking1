using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
