using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HandleErrors01
{
    public class BusinessExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly ILogger _logger;

        public BusinessExceptionFilter(ILogger<BusinessExceptionFilter> logger)
        {
            _logger = logger;
        }

        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BusinessException exception)
            {
                string exceptionCode = exception.ExceptionCode;
                string msg = exception.Message;
                int statusCode = exception.StatusCode;

                var result = new ResultData();
                result.SetCodeMsg(exceptionCode, msg);
                context.Result = new ObjectResult(result)
                {
                    StatusCode = statusCode
                };

                context.ExceptionHandled = true;

                _logger.LogError("[BusinessException] ExceptionCode: {ExceptionCode}, Message: {Message}, StatusCode: {statusCode}",
                    exceptionCode, msg, statusCode);
            }
        }
    }
}
