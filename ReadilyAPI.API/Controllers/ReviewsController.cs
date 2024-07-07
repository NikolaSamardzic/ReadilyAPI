using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Reviews;
using ReadilyAPI.Application.UseCases.DTO.Review;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public ReviewsController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }


        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewDto dto, ICreateReviewCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateReviewDto dto, IUpdateReviewCommand command)
        {
            dto.Id = id;

            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }
    }
}
