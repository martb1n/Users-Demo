using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    class CreateUserHandler : IRequestHandler<CreateUserQuery, bool>
    {
        private readonly IUserService userService;
        public CreateUserHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<bool> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            var createUser = await userService.Create(request.Users);
            if (createUser)
            {
                return true;
            }
            return false;
        }
    }
}
