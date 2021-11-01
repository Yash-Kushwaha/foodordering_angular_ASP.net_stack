using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderFood_web_API.Exceptions;

namespace OrderFood_web_API.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;

            if (exceptionType == typeof(OrderFoodNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(OrderFoodAlreadyExistsException))
            {
                context.Result = new ConflictObjectResult(message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }

        }
    }
}
