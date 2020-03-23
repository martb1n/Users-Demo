using FluentValidation;

namespace Users_Demo.Validator.Models.University
{
    public class UniversityModelValidator : AbstractValidator<DAL.Models.University>
    {
        public UniversityModelValidator()
        {
            RuleFor(x => x.Id).NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .Length(2, 50);

            RuleFor(x => x.IsDeleted).NotNull();

            RuleFor(x => x.IsActive).NotNull();
        }
    }
}
