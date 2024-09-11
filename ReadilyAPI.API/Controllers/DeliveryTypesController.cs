using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTypesController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public DeliveryTypesController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<DeliveryTypesController>
        [HttpGet]
        public IActionResult Get([FromQuery] DeliveryTypeSearch search, IGetDeliveryTypesQuery query)
            => Ok(_queryHandler.HandleQuery(query, search));

        // GET api/<DeliveryTypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, IFindDeliveryTypeQuery query)
            => Ok(_queryHandler.HandleQuery(query, id));

        // POST api/<DeliveryTypesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateDeliveryTypeDto dto, ICreateDeliveryTypeCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<DeliveryTypesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateDeliveryTypeDto dto, IUpdateDeliveryTypeCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<DeliveryTypesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteDeliveryTypeCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }

        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, IActivateDeliveryTypeCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
