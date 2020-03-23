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
        private readonly IUserService _userService;
        public GetUserByIdHandler(IUserService userService) => _userService = userService;

        public Task<Users> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => _userService.GetByIdAsync(request.Id);
    }
}
