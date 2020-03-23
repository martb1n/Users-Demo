using FluentValidation;
using Users_Demo.Common.Requests.University;

namespace Users_Demo.Validator.Models.University
{
    public class UniversityByNameValidator : AbstractValidator<UniversityByName>
    {
        public UniversityByNameValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .Length(2, 50);
        }
    }
}
