using MediatR;

namespace Users_Demo.Handler.University.Request
{
    public class GetUniversityByIdQuery : IRequest<DAL.Models.University>
    {
        public GetUniversityByIdQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
