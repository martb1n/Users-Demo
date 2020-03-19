using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    public class GetUserHandler : IRequestHandler<GetUsersQuery, IEnumerable<Users>>
    {
        private readonly IUserService userService;
        public GetUserHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IEnumerable<Users>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.Get();
            return result;
        }
    }
}
