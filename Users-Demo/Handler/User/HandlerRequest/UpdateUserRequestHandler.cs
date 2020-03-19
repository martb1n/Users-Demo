using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.HandlerRequest
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserQuery, bool>
    {
        private readonly IUserService userService;
        public UpdateUserRequestHandler(IUserService userService)
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
