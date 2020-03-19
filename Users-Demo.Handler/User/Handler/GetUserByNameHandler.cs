using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.Handler
{
    class GetUserByNameHandler : IRequestHandler<GetUsersByNameQuery, IEnumerable<Users>>
    {
        private readonly IUserService userService;
        public GetUserByNameHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IEnumerable<Users>> Handle(GetUsersByNameQuery request, CancellationToken cancellationToken)
        {
            if (request.FirstName != null)
                return await GetByFName(request.FirstName);
            return await GetByLName(request.LastName);
        }
        private async Task<IEnumerable<Users>> GetByFName(string firstName)
        {
            var user = await userService.GetByFirstName(firstName);
            return user;
        }
        private async Task<IEnumerable<Users>> GetByLName(string lastName)
        {
            var user = await userService.GetByLastname(lastName);
            return user;
        }
    }
}
