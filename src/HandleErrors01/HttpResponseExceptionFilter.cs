using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HandleErrors01
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                var ex = new BusinessException("code", "msg", 400);
                context.Result = new ObjectResult(ex)
                {
                    StatusCode = ex.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
