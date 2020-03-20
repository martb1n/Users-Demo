using MediatR;
using Users_Demo.DAL.Models;

namespace Users_Demo.Handler.User.Request
{
    public class UpdateUserQuery : IRequest<bool>
    {
        public UpdateUserQuery(Users user) => Users = user;
        public Users Users { get; set; }
    }
}
