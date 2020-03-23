using FluentValidation;
using Users_Demo.Common.Requests.Users;

namespace Users_Demo.Validator.Models.Users
{
    public class UsersByFirstNameValidator : AbstractValidator<UsersByFirstName>
    {
        public UsersByFirstNameValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .Length(2, 50);
        }
    }
}
