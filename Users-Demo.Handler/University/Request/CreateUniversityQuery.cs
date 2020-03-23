using MediatR;

namespace Users_Demo.Handler.University.Request
{
    public class CreateUniversityQuery : IRequest<bool>
    {
        public CreateUniversityQuery(DAL.Models.University university) => University = university;
        public DAL.Models.University University { get; set; }
    }
}
