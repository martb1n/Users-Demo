using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Users_Demo.Common.Requests.CommonRequest;
using Users_Demo.Common.Requests.Users;
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

        [HttpGet("GetById/")]
        public async Task<IActionResult> Get([FromQuery]RequestById req)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(req.Id));
            if (user != null)
                return Ok(user);
            return NoContent();
        }

        [HttpGet("GetByFirstName/")]
        public async Task<IActionResult> GetByFirstName([FromQuery]UsersByFirstName req)
        {
            var users = await _mediator.Send(new GetUsersByNameQuery(req.FirstName));
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpGet("GetByLastName/")]
        public async Task<IActionResult> GetByLastName([FromQuery]UsersByLastName req)
        {
            var users = await _mediator.Send(new GetUsersByNameQuery(lastName: req.LastName));
            if (users != null)
                return Ok(users);
            return NoContent();
        }

        [HttpPut]
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

        [HttpDelete]
        public async Task<ActionResult<Users>> Delete(RequestById req)
        {
            var delUser = await _mediator.Send(new DeleteUserQuery(req.Id));
            if (delUser)
                return Ok(true);
            return BadRequest();
        }
    }
}
