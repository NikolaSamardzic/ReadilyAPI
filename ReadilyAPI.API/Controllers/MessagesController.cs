using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Messages;
using ReadilyAPI.Application.UseCases.DTO.Messages;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public MessagesController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<MessagesController>
        [HttpGet]
        public IActionResult Get([FromQuery] MessageSearch search, IGetMessagesQuery query)
            => Ok(_queryHandler.HandleQuery(query, search));

        // POST api/<MessagesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMessageDto dto, ICreateMessageCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteMessageCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
