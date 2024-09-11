using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseSeedController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;

        public DatabaseSeedController(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        // GET: api/<DatabaseSeedController>
        [HttpGet]
        public IActionResult Get(IDatabaseSeedCommand command)
        {
            _commandHandler.HandleCommand(command, true);

            return Created();
        }
    }
}
