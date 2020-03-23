using MediatR;

namespace Users_Demo.Handler.University.Request
{
    public class UpdateUniversityQuery : IRequest<bool>
    {
        public UpdateUniversityQuery(DAL.Models.University university) => University = university;
        public DAL.Models.University University { get; set; }
    }
}
