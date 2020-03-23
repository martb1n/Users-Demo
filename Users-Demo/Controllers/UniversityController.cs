using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Users_Demo.Common.Requests.CommonRequest;
using Users_Demo.Common.Requests.University;
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

        [HttpGet("GetById/")]
        public async Task<IActionResult> Get([FromQuery]RequestById req)
        {
            var university = await _mediator.Send(new GetUniversityByIdQuery(req.Id));
            if (university != null)
                return Ok(university);
            return NoContent();
        }

        [HttpGet("GetUniversityByName")]
        public async Task<IActionResult> GetByName([FromQuery]UniversityByName req)
        {
            var university = await _mediator.Send(new GetUniversityByNameQuery(req.Name));
            if (university != null)
                return Ok(university);
            return NoContent();
        }

        [HttpPut]
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

        [HttpDelete]
        public async Task<ActionResult<University>> Delete([FromQuery]RequestById req)
        {
            var delUniversity = await _mediator.Send(new DeleteUniversityQuery(req.Id));
            if (delUniversity)
                return Ok(true);
            return BadRequest();
        }
    }
}
