using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs;

[ApiController()]
public class ReferralsController : ReferralsControllerBase
{
    public ReferralsController(IReferralsService service)
        : base(service) { }
}
