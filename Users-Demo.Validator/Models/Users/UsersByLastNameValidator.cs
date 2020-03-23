using FluentValidation;
using Users_Demo.Common.Requests.Users;

namespace Users_Demo.Validator.Models.Users
{
    public class UsersByLastNameValidator : AbstractValidator<UsersByLastName>
    {
        public UsersByLastNameValidator()
        {
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .Length(2, 50);
        }
    }
}
