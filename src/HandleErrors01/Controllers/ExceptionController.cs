using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HandleErrors01.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionController : ControllerBase
{
    [Route("/error")]
    public IActionResult HandleError([FromServices] IHostEnvironment hostEnvironment)
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        var error = exceptionHandlerFeature.Error;

        return  Problem();
    }
        
}