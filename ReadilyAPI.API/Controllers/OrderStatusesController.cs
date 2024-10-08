﻿using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.OrderStatuses;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public OrderStatusesController([FromServices] ICommandHandler commandHandler, [FromServices] IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<OrderStatusesController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderStatusSearch search, IGetOrderStatusQuery query)
            => Ok(_queryHandler.HandleQuery(query, search));

        // GET api/<OrderStatusesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, IFindOrderStatusQuery query)
            => Ok(_queryHandler.HandleQuery(query,id));

        // POST api/<OrderStatusesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderStatusDto dto, [FromServices] ICreateOrderStatusCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<OrderStatusesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOrderStatusDto dto, IUpdateOrderStatusCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<OrderStatusesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteOrderStatusCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return StatusCode(204);
        }

        // PATCH api/<OrderStatusesController>/5/activate
        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, IActivateOrderStatusCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return StatusCode(204);
        }
    }
}
