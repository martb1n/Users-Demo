using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.University.Request;

namespace Users_Demo.Controllers
{
    [Route("api/university")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UniversityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var university = await _mediator.Send(new GetUniversityQuery());
            if(university.Any()) 
                return Ok(university);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var university = await _mediator.Send(new GetUniversityByIdQuery(id));
            if (university != null)
                return Ok(university);
            return NoContent();
        }

        [HttpGet("GetUniversityByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var university = await _mediator.Send(new GetUniversityByNameQuery(name));
            if (university != null)
                return Ok(university);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(University university)
        {
            var putUniversity = await _mediator.Send(new UpdateUniversityQuery(university));
            if (putUniversity)
                return Ok(true);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(University university)
        {
            var postUniversity = await _mediator.Send(new CreateUniversityQuery(university));
            if (postUniversity)
                return CreatedAtAction($"Post", "Success");
            return StatusCode(409);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<University>> Delete(int id)
        {
            var delUniversity = await _mediator.Send(new DeleteUniversityQuery(id));
            if (delUniversity)
                return Ok(true);
            return BadRequest();
        }
    }
}
