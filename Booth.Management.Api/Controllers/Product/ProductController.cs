﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booth.Application.Infrastructure;
using Booth.Application.Queries.Product;
using Booth.Application.Commands.Product;
using Booth.Management.Api.Infrastructure;

namespace Booth.Product.Api.Controllers
{
    [Route("v1/product")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        public QueryExecutor _queryExecutor;
        public CommandExecutor _commandExecutor;

        public ProductController(QueryExecutor queryExecutor,
                                 CommandExecutor commandExecutor)
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        [HttpGet("listing")]
        public async Task<IActionResult> Listing([FromQuery] ProductListingQuery query)
        {
            var result = await _queryExecutor.ExecuteAsync<ProductListingQuery, ProductListingQueryResult>(query);

            return QueryResultToHttpResponse(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details([FromQuery] ProductDetailsQuery query)
        {
            var result = await _queryExecutor.ExecuteAsync<ProductDetailsQuery, ProductDetailsQueryResult>(query);

            return QueryResultToHttpResponse(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaceProductCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Created);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
        {
            var result = await _commandExecutor.ExecuteAsync(command);

            return CommandResultToHttpResponse(result, EntityStatusCode.Deleted);
        }
    }
}
