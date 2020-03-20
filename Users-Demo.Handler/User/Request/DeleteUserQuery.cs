using MediatR;

namespace Users_Demo.Handler.User.Request
{
    public class DeleteUserQuery : IRequest<bool>
    {
        public DeleteUserQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
