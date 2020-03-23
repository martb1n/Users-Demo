using System;
using FluentValidation;

namespace Users_Demo.Validator.Models.Users
{
    public class UsersModelValidator : AbstractValidator<DAL.Models.Users>
    {
        public UsersModelValidator()
        {
            RuleFor(x => x.Id).NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .Length(2, 50);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$")
                .Length(2, 50);

            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .Must(BeAValidDate);

            RuleFor(x => x.IsDeleted).NotNull();

            RuleFor(x => x.IsActive).NotNull();
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
