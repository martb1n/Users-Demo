using MediatR;
using Users_Demo.DAL.Models;

namespace Users_Demo.Handler.User.Request
{
    public class CreateUserQuery : IRequest<bool>
    {
        public CreateUserQuery(Users user) => Users = user;
        public Users Users { get; set; }
    }
}
