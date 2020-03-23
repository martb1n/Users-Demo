using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserQuery, bool>
    {
        private readonly IUserService _userService;
        public DeleteUserHandler(IUserService userService) => _userService = userService;
        public Task<bool> Handle(DeleteUserQuery request, CancellationToken cancellationToken) => _userService.DeleteAsync(request.Id);
    }
}
