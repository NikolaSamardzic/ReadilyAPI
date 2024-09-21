using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Shop;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.Application.UseCases.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public ShopController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET api/<ShopController>/cart/5
        [HttpGet("cart/{id}")]
        public IActionResult Get(int id, IFindCartQuery query)
            => Ok(_queryHandler.HandleQuery(query, id));

        // POST api/<ShopController>
        [HttpPost("cart")]
        public IActionResult Post([FromBody] CreateCartDto dto, ICreateCartCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // POST api/<ShopController>/submit
        [HttpPost("submit")]
        public IActionResult Submit([FromBody] SubmitOrderDto dto, ISumbitOrderCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}
