using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booth.Application.Infrastructure;
using Booth.Management.Api.Infrastructure;
using Booth.Application.Commands.ProductSupplier;

namespace Booth.Product.Api.Controllers
{
    [Route("v1/productsupplier")]
    [ApiController]
    public class ProductSupplierController : BaseApiController
    {
        public QueryExecutor _queryExecutor;
        public CommandExecutor _commandExecutor;

        public ProductSupplierController(QueryExecutor queryExecutor,
                                         CommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaceProductSupplierCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }
    }
}
