using System;
using FluentValidation;
using Users_Demo.DAL.Models;

namespace Users_Demo.Validator.Models
{
    public class UsersModelValidator : AbstractValidator<Users>
    {
        public UsersModelValidator()
        {
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
