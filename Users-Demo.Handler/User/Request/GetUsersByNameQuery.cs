using MediatR;
using System.Collections.Generic;
using Users_Demo.DAL.Models;

namespace Users_Demo.Handler.User.Request
{
    public class GetUsersByNameQuery : IRequest<IEnumerable<Users>>
    {
        public GetUsersByNameQuery(string firstName = null, string lastName = null)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
