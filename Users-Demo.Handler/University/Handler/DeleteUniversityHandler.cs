using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users_Demo.Handler.University.Request;
using Users_Demo.Services.Interface;

namespace Users_Demo.Handler.University.Handler
{
    public class DeleteUniversityHandler : IRequestHandler<DeleteUniversityQuery, bool>
    {
        private readonly IUniversityService _universityService;
        public DeleteUniversityHandler(IUniversityService universityService) => _universityService = universityService;
        public Task<bool> Handle(DeleteUniversityQuery request, CancellationToken cancellationToken) => _universityService.DeleteAsync(request.Id);
    }
}
