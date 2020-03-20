using MediatR;
using Users_Demo.DAL.Models;

namespace Users_Demo.Handler.User.Request
{
    public class GetUserByIdQuery : IRequest<Users>
    {
        public GetUserByIdQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
