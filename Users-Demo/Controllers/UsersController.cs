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
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            if(users.Any()) 
                return Ok(users);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        [HttpGet("GetUsersByFirstName/{firstName}")]
        public async Task<IActionResult> GetUsersByFirstName(string firstName)
        {
            var users = await _mediator.Send(new GetUsersByNameQuery(firstName: firstName));
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpGet("GetUsersByLastName/{lastName}")]
        public async Task<IActionResult> GetUsersByLastName(string lastName)
        {
            var users = await _mediator.Send(new GetUsersByNameQuery(lastName: lastName));
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(Users users)
        {
            var putUser = await _mediator.Send(new UpdateUserQuery(users));
            if (putUser)
                return Ok(true);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostUsers(Users users)
        {
            var postUser = await _mediator.Send(new CreateUserQuery(users));
            if (postUser)
                return CreatedAtAction($"PostUsers", "Success");
            return StatusCode(409);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var delUser = await _mediator.Send(new DeleteUserQuery(id));
            if (delUser)
                return Ok(true);
            return BadRequest();
        }
    }
}
