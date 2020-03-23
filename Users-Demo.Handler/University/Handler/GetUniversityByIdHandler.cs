using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Demo.Handler.University.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.University.Handler
{
    public class GetUniversityByIdHandler : IRequestHandler<GetUniversityByIdQuery, DAL.Models.University>
    {
        private readonly IUniversityService _universityService;
        public GetUniversityByIdHandler(IUniversityService universityService) => _universityService = universityService;

        public Task<DAL.Models.University> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken) => _universityService.GetByIdAsync(request.Id);
    }
}
