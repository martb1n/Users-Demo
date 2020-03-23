using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Demo.Handler.University.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.University.Handler
{
    public class CreateUniversityHandler : IRequestHandler<CreateUniversityQuery, bool>
    {
        private readonly IUniversityService _universityService;
        public CreateUniversityHandler(IUniversityService universityService) => _universityService = universityService;

        public async Task<bool> Handle(CreateUniversityQuery request, CancellationToken cancellationToken) => await _universityService.CreateAsync(request.University);
    }
}
