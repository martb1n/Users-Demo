using FluentValidation;

namespace Users_Demo.Validators.Users
{
    public class UserModelValidationRule : AbstractValidator<DAL.Models.Users>
    {
        public UserModelValidationRule()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithMessage("Please specify a FirstName");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithMessage("Please specify a LastName");

            RuleFor(x => x.IsActive)
                .NotEmpty()
                .NotNull()
                .Must(x => true);

            RuleFor(x => x.IsDeleted)
                .NotEmpty()
                .NotNull()
                .Must(x => false);
        }
    }
}
