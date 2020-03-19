using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Users>
    {
        private readonly IUserService userService;
        public GetUserByIdHandler(IUserService userService)
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
