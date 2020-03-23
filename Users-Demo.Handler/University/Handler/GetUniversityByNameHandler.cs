using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Demo.Handler.University.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.University.Handler
{
    public class GetUniversityByNameHandler : IRequestHandler<GetUniversityByNameQuery, IEnumerable<DAL.Models.University>>
    {
        private readonly IUniversityService _universityService;
        public GetUniversityByNameHandler(IUniversityService universityService) => _universityService = universityService;

        public async Task<IEnumerable<DAL.Models.University>> Handle(GetUniversityByNameQuery request, CancellationToken cancellationToken) => await _universityService.GetByName(request.Name);
    }
}
