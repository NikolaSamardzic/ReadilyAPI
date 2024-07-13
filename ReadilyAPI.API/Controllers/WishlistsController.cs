using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Wishlist;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public WishlistsController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<WishlistsController>
        [HttpGet]
        public IActionResult Get([FromQuery] WishlistSearch search, IGetWishlistQuery query)
            => Ok(_queryHandler.HandleQuery(query, search));

        // POST api/<WishlistsController>
        [HttpPost]
        public void Post([FromBody] CreateWishlistDto dto, ICreateWishlistCommand command)
        {
            _commandHandler.HandleCommand(command,dto);
        }

        // DELETE api/<WishlistsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteWishlistCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
