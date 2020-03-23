using System.Collections.Generic;
using MediatR;

namespace Users_Demo.Handler.University.Request
{
    public class GetUniversityByNameQuery : IRequest<IEnumerable<DAL.Models.University>>
    {
        public GetUniversityByNameQuery(string name = null)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
