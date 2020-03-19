using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users_Demo.DAL.Models;
using Users_Demo.Handler.User.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.User.HandlerRequest
{
    public class GetUsersByNameRequestHandler : IRequestHandler<GetUsersByNameQuery, IEnumerable<Users_Demo.DAL.Models.Users>>
    {
        private readonly IUserService userService;
        public GetUsersByNameRequestHandler(IUserService userService)
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
