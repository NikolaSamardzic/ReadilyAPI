//using FluentValidation.Results;
//using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.UseCases.Commands;
using ReadilyAPI.Implementation.UseCases.Commands.Categories;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public CategoriesController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search, [FromServices] IGetCategoriesQuery query) => Ok(_queryHandler.HandleQuery(query, search));

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IFindCategoryQuery query) 
            => Ok(_queryHandler.HandleQuery(query, id));

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            _commandHandler.HandleCommand(command,dto);
            return StatusCode(201);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDto dto, IUpdateCategoryCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(204);
        }

        //DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }

        //PATCH api/<CategoriesController>/5/activate
        [HttpPatch("{id}/activate")]
        public IActionResult Activate(int id, [FromServices] IActivateCategoryCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
