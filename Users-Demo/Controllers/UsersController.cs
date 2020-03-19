using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMediator mediator;

        public UsersController(IUserService userService, IMediator mediator)
        {
            this.userService = userService;
            this.mediator = mediator;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await mediator.Send(new GetUsersQuery());
            if(users.Any()) 
                return Ok(users);
            return NotFound();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            //var user = await userService.GetById(id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            //return Ok(user);

            var user = await mediator.Send(new GetUserByIdQuery(id));
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpGet("GetUsersByFirstName/{firstName}")]
        public async Task<IActionResult> GetUsersByFirstName(string firstName)
        {
            //var users = await userService.GetByFirstName(firstName);
            //if (users != null)
            //    return Ok(users);
            //return NotFound();

            var users = await mediator.Send(new GetUsersByNameQuery(firstName: firstName));
            if (users != null)
                return Ok(users);
            return NotFound();
        }

        [HttpGet("GetUsersByLastName/{lastName}")]
        public async Task<IActionResult> GetUsersByLastName(string lastName)
        {
            //var users = await userService.GetByLastname(lastName);
            //if (users != null)
            //    return Ok(users);
            //return NotFound();
            var users = await mediator.Send(new GetUsersByNameQuery(lastName: lastName));
            if (users != null)
                return Ok(users);
            return NotFound();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(Users users)
        {
            //var putUser = await  userService.Update(users);
            //if (putUser)
            //    return Ok(putUser);
            //else
            //    return BadRequest();
            var putUser = await mediator.Send(new UpdateUserQuery(users));
            if (putUser)
                return Ok(putUser);
            else
                return BadRequest();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers(Users users)
        {
            //var postUser = await userService.Create(users);
            //if (postUser)
            //    return CreatedAtAction("PostUsers", "Success");
            //else
            //    return StatusCode(409);
            var postUser = await mediator.Send(new CreateUserQuery(users));
            if (postUser)
                return CreatedAtAction("PostUsers", "Success");
            else
                return StatusCode(409);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            //var delUser = await userService.Delete(id);
            //if(delUser) 
            //    return Ok(delUser);
            //else
            //    return BadRequest();
            var delUser = await mediator.Send(new DeleteUserQuery(id));
            if (delUser)
                return Ok(delUser);
            else
                return BadRequest();
        }
    }
}
