using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.HandlerRequest
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdQuery, Users_Demo.DAL.Models.Users>
    {
        private readonly IUserService userService;
        public GetUserByIdRequestHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<Users> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await userService.GetById(request.Id);
            return response;
        }
    }
}
