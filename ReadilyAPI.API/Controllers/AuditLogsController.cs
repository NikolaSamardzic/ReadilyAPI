using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly IQueryHandler _queryHandler;

        public AuditLogsController(IQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }
        
        // GET: api/<AuditLogsController>
        [HttpGet("entries")]
        public IActionResult Entries([FromQuery] LogEntriesSearch search, IGetLogEntriesQuery query)
        => Ok(_queryHandler.HandleQuery(query,search));

        [HttpGet("errors")]
        public IActionResult Errors([FromQuery] ErrorLogSearch search, IGetErrorLogsQuery query)
        => Ok(_queryHandler.HandleQuery(query, search));
        
        [HttpGet("errors/{id}")]
        public IActionResult ErrorsFind(Guid id, IFindErrorLogQuery query)
        => Ok(_queryHandler.HandleQuery(query, id));
    }
}
