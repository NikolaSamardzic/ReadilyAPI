using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCasesController : ControllerBase
    {
        // GET: api/<UseCasesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UseCaseInfo.AllUseCases);
        }
    }
}
