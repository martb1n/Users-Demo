using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    class UpdateUserHandler : IRequestHandler<UpdateUserQuery, bool>
    {
        private readonly IUserService userService;
        public UpdateUserHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<bool> Handle(UpdateUserQuery request, CancellationToken cancellationToken)
        {
            var updateUser = await userService.Update(request.Users);
            if (updateUser)
                return true;
            return false;
        }
    }
}
