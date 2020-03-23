using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    public class GetUserHandler : IRequestHandler<GetUsersQuery, IEnumerable<Users>>
    {
        private readonly IUserService _userService;
        public GetUserHandler(IUserService userService) => _userService = userService;

        public Task<IEnumerable<Users>> Handle(GetUsersQuery request, CancellationToken cancellationToken) => Task.FromResult(_userService.Get().AsEnumerable());
    }
}
