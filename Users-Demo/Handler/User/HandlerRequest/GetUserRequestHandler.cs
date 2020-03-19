using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.HandlerRequest
{
    public class GetUserRequestHandler : IRequestHandler<GetUsersQuery, IEnumerable<Users_Demo.DAL.Models.Users>>
    {
        private readonly IUserService userService;
        public GetUserRequestHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IEnumerable<DAL.Models.Users>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.Get();
            return result;
        }
    }
}
