using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public PublishersController([FromServices] ICommandHandler commandHandler, [FromServices] IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }


        // GET: api/<PublishersController>
        [HttpGet]
        public IActionResult Get([FromQuery] PublisherSearch search, [FromServices] IGetPublishersQuery query) => Ok(_queryHandler.HandleQuery(query, search));

        // GET api/<PublishersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, IFindPublisherQuery query) => Ok(_queryHandler.HandleQuery(query,id));

        // POST api/<PublishersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePublisherDto dto, [FromServices] ICreatePublisherCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<PublishersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePublisherDto dto, [FromServices] IUpdatePublisherCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(204);
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePublisherCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return StatusCode(204);
        }

        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, [FromServices] IActivatePublisherCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return StatusCode(204);
        }
    }
}
