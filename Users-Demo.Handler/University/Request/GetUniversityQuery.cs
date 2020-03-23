using System.Collections.Generic;
using MediatR;

namespace Users_Demo.Handler.University.Request
{
    public class GetUniversityQuery : IRequest<IEnumerable<DAL.Models.University>>
    {
    }
}
