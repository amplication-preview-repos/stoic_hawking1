using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs;

[ApiController()]
public class CryptocurrenciesController : CryptocurrenciesControllerBase
{
    public CryptocurrenciesController(ICryptocurrenciesService service)
        : base(service) { }
}
