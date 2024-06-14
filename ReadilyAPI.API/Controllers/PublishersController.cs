using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.Application.UseCases.DTO.Publisher;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public PublishersController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }


        // GET: api/<PublishersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PublishersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublishersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePublisherDto dto, ICreatePublisherCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<PublishersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
