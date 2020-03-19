using MediatR;

namespace Users_Demo.Handler.User.Request
{
    public class DeleteUserQuery : IRequest<bool>
    {
        public DeleteUserQuery(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
