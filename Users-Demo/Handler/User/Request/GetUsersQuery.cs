using MediatR;
using System.Collections.Generic;

namespace Users_Demo.Handler.User.Request
{
    public class GetUsersQuery : IRequest<IEnumerable<Users_Demo.DAL.Models.Users>>
    {
    }
}
