using MediatR;

namespace Users_Demo.Handler.University.Request
{
    public class DeleteUniversityQuery : IRequest<bool>
    {
        public DeleteUniversityQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
