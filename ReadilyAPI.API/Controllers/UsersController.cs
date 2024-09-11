using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public UsersController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, IGetUsersQuery query)
        => Ok(_queryHandler.HandleQuery(query, search));

        [HttpGet("profile")]
        public IActionResult Get(IApplicationActor actor, IUserProfileQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,actor.Id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto dto, ICreateUserCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return Ok(new {message = "Your account has been created successfully. Please check your email for activation instructions. Thank you!" });
        }

        // PUT api/<UsersController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] UpdateUserDto dto, IApplicationActor actor, IUpdateUserCommand command)
        {
            dto.Id = actor.Id;
            _commandHandler.HandleCommand(command,dto);
            return StatusCode(204);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete()]
        public IActionResult Delete(IDeleteUserCommand command, IApplicationActor actor)
        {
            _commandHandler.HandleCommand(command,actor.Id);
            return StatusCode(204);
        }

        [HttpGet("{id}/verify")]
        public IActionResult Verify(string id, IVerifyUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return Ok(new {message = "User is verified."});
        }

        [HttpPatch("{id}/ban")]
        public IActionResult Ban(int id, IBanUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }

        [HttpPatch("{id}/unban")]
        public IActionResult Unban(int id, IUnBanUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }

        [HttpPost("favoriteCategories")]
        public IActionResult FavoriteCategories([FromBody] CreateUserFavoriteCategoriesDto dto, ICreateUserFavoriteCategoriesCommand command, IApplicationActor actor)
        {
            dto.UserId = actor.Id;

            _commandHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        [HttpPost("userUseCase")]
        public IActionResult UseUserCase([FromBody] CreateUserUseCaseDto dto, ICreateUserUseCaseCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }
    }
}
