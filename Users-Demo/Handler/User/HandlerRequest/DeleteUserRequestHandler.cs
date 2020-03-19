using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.HandlerRequest
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserQuery, bool>
    {
        private readonly IUserService userService;
        public DeleteUserRequestHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<bool> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.Delete(request.Id);
            if (user)
                return true;
            return false;
        }
    }
}
