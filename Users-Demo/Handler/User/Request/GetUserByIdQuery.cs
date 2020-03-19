using MediatR;
using System.Collections.Generic;

namespace Users_Demo.Handler.User.Request
{
    public class GetUserByIdQuery : IRequest<Users_Demo.DAL.Models.Users>
    {
        public GetUserByIdQuery(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
