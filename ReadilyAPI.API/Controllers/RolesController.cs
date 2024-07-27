using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public RolesController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search, IGetRolesQuery query) => Ok(_queryHandler.HandleQuery(query, search));

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, IFindRoleQuery query) 
            => Ok(_queryHandler.HandleQuery(query, id));

        // POST api/<RolesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoleDto dto, [FromServices] ICreateRoleCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateRoleDto dto, IUpdateRoleCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(204);
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteRoleCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }

        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, IActivateRoleCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
