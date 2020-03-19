using FluentValidation;
using Users_Demo.DAL.Models;

namespace Users_Demo.Validations.Validations
{
    public class UsersValidation : AbstractValidator<Users>
    {
        public UsersValidation()
        {
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty();
        }
    }
}
