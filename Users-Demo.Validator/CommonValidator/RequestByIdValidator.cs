using FluentValidation;
using Users_Demo.Common.Requests.CommonRequest;

namespace Users_Demo.Validator.CommonValidator
{
    public class RequestByIdValidator : AbstractValidator<RequestById>
    {
        public RequestByIdValidator()
        {
            RuleFor(x => x.Id).NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}
