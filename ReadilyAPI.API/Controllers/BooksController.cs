using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.Application.UseCases.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public BooksController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, IFindBookQuery query) => Ok(_queryHandler.HandleQuery(query, id));

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDto dto, ICreateBookCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return Ok();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookDto dto, IUpdateBookCommand command)
        {
            dto.Id = id;

            _commandHandler.HandleCommand<UpdateBookDto>(command, dto);

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteBookCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return NoContent();
        }

        // PATCH api/<BooksController>/5/activate
        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, IActivateBookCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
