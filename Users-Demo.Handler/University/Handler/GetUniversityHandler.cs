using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Demo.Handler.University.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.University.Handler
{
    public class GetUniversityHandler : IRequestHandler<GetUniversityQuery, IEnumerable<DAL.Models.University>>
    {
        private readonly IUniversityService _universityService;
        public GetUniversityHandler(IUniversityService universityService) => _universityService = universityService;

        public Task<IEnumerable<DAL.Models.University>> Handle(GetUniversityQuery request, CancellationToken cancellationToken) => Task.FromResult(_universityService.Get().AsEnumerable());
    }
}
