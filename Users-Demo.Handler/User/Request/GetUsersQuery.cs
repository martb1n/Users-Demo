using MediatR;
using System.Collections.Generic;
using Users_Demo.DAL.Models;

namespace Users_Demo.Handler.User.Request
{
    public class GetUsersQuery : IRequest<IEnumerable<Users>>
    {
    }
}
