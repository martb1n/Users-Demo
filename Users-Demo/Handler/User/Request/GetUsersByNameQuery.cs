using MediatR;
using System.Collections.Generic;

namespace Users_Demo.Handler.User.Request
{
    public class GetUsersByNameQuery : IRequest<IEnumerable<Users_Demo.DAL.Models.Users>>
    {
        public GetUsersByNameQuery(string firstName = null, string lastName = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
