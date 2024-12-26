using Microsoft.AspNetCore.Mvc;

namespace CryptoBotClone.APIs;

[ApiController()]
public class TransactionsController : TransactionsControllerBase
{
    public TransactionsController(ITransactionsService service)
        : base(service) { }
}
