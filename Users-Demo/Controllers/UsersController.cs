using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;

namespace Users_Demo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            if(users.Any()) 
                return Ok(users);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        [HttpGet("GetByFirstName/{firstName}")]
        public async Task<IActionResult> GetByFirstName(string firstName)
        {
            var users = await _mediator.Send(new GetUsersByNameQuery(firstName: firstName));
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpGet("GetByLastName/{lastName}")]
        public async Task<IActionResult> GetByLastName(string lastName)
        {
            var users = await _mediator.Send(new GetUsersByNameQuery(lastName: lastName));
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Users users)
        {
            var putUser = await _mediator.Send(new UpdateUserQuery(users));
            if (putUser)
                return Ok(true);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users users)
        {
            var postUser = await _mediator.Send(new CreateUserQuery(users));
            if (postUser)
                return CreatedAtAction($"Post", "Success");
            return StatusCode(409);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> Delete(int id)
        {
            var delUser = await _mediator.Send(new DeleteUserQuery(id));
            if (delUser)
                return Ok(true);
            return BadRequest();
        }
    }
}
