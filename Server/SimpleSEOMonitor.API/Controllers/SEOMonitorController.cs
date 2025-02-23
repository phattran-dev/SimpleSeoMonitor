using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleSeoMonitor.Domain.Interfaces;
using SimpleSeoMonitor.Domain.Models;
using SimpleSEOMonitor.Application.Queries.GetSEOIndexes;

namespace SimpleSEOMonitor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class SEOMonitorController(IQueryExecutor _queryExecutor) : ControllerBase
    {
        [HttpGet("GetSeoIndexes")]
        public async Task<ActionResult<BaseResponse<List<int>>>> GetSEOIndexesAsync([FromQuery] GetSEOIndexesQuery query)
        {
            var result = await _queryExecutor.ExecuteAsync(query);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
