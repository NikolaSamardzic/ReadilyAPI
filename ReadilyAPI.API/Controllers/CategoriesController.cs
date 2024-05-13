//using FluentValidation.Results;
//using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.API.DTO.Category;
using ReadilyAPI.API.Extensions;
using ReadilyAPI.API.Validation;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ReadilyContext _context;
        public CategoriesController(ReadilyContext context) {
            this._context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromServices] CreateCategoryDtoValidator validator,[FromBody] CreateCatregoryDto dto)
        {
            try
            {
                ValidationResult result = validator.Validate(dto);

                if(!result.IsValid)
                {
                    return result.ToUnprocessableEntity();
                }

                Category category = new Category{
                    Name = dto.Name,
                    ParentId = dto.ParentId,
                };

                _context.Categories.Add(category);
                _context.SaveChanges();

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
