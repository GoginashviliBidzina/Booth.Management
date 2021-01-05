using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booth.Application.Commands.Booth;
using Booth.Application.Infrastructure;
using Booth.Management.Api.Infrastructure;

namespace Booth.Management.Api.Controllers
{
    [Route("v1/boothstaff")]
    [ApiController]
    public class BoothStaffController : BaseApiController
    {
        public QueryExecutor _queryExecutor;
        public CommandExecutor _commandExecutor;

        public BoothStaffController(QueryExecutor queryExecutor,
                               CommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaceBoothStaffCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBoothStaffCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }

        [HttpDelete("update")]
        public async Task<IActionResult> Delete([FromBody] DeleteBoothStaffCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }
    }
}
