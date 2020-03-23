using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Demo.Handler.University.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.University.Handler
{
    public class UpdateUniversityHandler : IRequestHandler<UpdateUniversityQuery, bool>
    {
        private readonly IUniversityService _universityService;
        public UpdateUniversityHandler(IUniversityService universityService) => _universityService = universityService;
        public async Task<bool> Handle(UpdateUniversityQuery request, CancellationToken cancellationToken) => await _universityService.UpdateAsync(request.University);
    }
}
