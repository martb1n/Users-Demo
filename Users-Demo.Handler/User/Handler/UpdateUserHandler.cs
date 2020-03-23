using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    class UpdateUserHandler : IRequestHandler<UpdateUserQuery, bool>
    {
        private readonly IUserService _userService;
        public UpdateUserHandler(IUserService userService) => _userService = userService;
        public async Task<bool> Handle(UpdateUserQuery request, CancellationToken cancellationToken) => await _userService.UpdateAsync(request.Users);
    }
}
