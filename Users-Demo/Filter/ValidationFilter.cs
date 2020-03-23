using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Users_Demo.Filter
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors);
                var message = errors
                    .Select(w => string.IsNullOrEmpty(w.ErrorMessage) ? w.Exception.Message : w.ErrorMessage);
                context.Result = new BadRequestObjectResult(new { error = message });
            }
            await next();
        }
    }
}
