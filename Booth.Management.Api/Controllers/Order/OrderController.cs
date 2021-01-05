using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booth.Application.Infrastructure;
using Booth.Application.Commands.Order;
using Booth.Management.Api.Infrastructure;

namespace Booth.Management.Api.Controllers
{
    [Route("v1/order")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        public QueryExecutor _queryExecutor;
        public CommandExecutor _commandExecutor;

        public OrderController(QueryExecutor queryExecutor,
                               CommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaceOrderCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }
    }
}
