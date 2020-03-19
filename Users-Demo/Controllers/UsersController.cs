using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Users_Demo.DAL;
using Users_Demo.DAL.Models;
using Users_Demo.Services.Interface;

namespace Users_Demo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersDemoContext _context;
        private readonly IUserService userService;

        public UsersController(UsersDemoContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.Get();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var user = await userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(Users users)
        {
            var putUser = await  userService.Update(users);
            if (putUser)
                return Ok(putUser);
            else
                return BadRequest();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            var postUser = await userService.Create(users);
            if (postUser)
                return CreatedAtAction("PostUsers", "Success");
            else
                return StatusCode(409);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var delUser = await userService.Delete(id);
            if(delUser) 
                return Ok(delUser);
            else
                return BadRequest();
        }

        [HttpGet("GetUsersByFirstName/{firstName}")]
        public async Task<IActionResult> GetUsersByFirstName(string firstName)
        {
            var users = await userService.GetByFirstName(firstName);
            if(users != null)
                return Ok(users);
            return NotFound();
        }

        [HttpGet("GetUsersByLastName/{lastName}")]
        public async Task<IActionResult> GetUsersByLastName(string lastName)
        {
            var users = await userService.GetByLastname(lastName);
            if (users != null)
                return Ok(users);
            return NotFound();
        }
    }
}
