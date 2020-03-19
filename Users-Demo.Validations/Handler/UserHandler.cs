using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Users_Demo.Validations.Handler
{
    public class UserHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;
        public UserHandler(IEnumerable<IValidator<TRequest>> validator) => this.validator = validator;
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var failures = validator.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();
            if(failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
