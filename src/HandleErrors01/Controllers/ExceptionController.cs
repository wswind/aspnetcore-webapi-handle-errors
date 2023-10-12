using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HandleErrors01.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionController : ControllerBase
{
    private readonly ILogger<ExceptionController> _logger;

    public ExceptionController(ILogger<ExceptionController> logger)
    {
        _logger = logger;
    }

    [Route("/error")]
    public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        if(exceptionHandlerFeature == null)
        {
            var badRequestResult = new ResultData();
            badRequestResult.SetCodeMsg("BadRequest", "Request not allowed.");

            return StatusCode(StatusCodes.Status400BadRequest, badRequestResult);
        }
        
        var error = exceptionHandlerFeature.Error;
        var message = error.Message;

        var result = new ResultData();

        if (hostEnvironment.IsDevelopment())
        {
            var stackTrace = error.StackTrace;
            result.SetCodeMsg("ServerError", $"ErrorMessage: {message}  StackTrace: {stackTrace}");
        }
        else
        {
            result.SetCodeMsg("ServerError", "An error occured while processing your request.");
        }

        _logger.LogError("UnhandledException: {message}", message);

        //return  Problem();
        return StatusCode(StatusCodes.Status500InternalServerError, result);
    }
        
}