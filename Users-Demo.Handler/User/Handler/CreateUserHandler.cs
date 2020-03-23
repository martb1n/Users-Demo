using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    class CreateUserHandler : IRequestHandler<CreateUserQuery, bool>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService) => _userService = userService;

        public async Task<bool> Handle(CreateUserQuery request, CancellationToken cancellationToken) => await _userService.CreateAsync(request.Users);
    }
}
