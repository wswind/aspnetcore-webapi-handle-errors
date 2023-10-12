using Microsoft.AspNetCore.Mvc;

namespace HandleErrors01.Controllers;


[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromServices] IHostEnvironment hostEnvironment)
    {
        throw new Exception("this is a test exception");
        //throw new BusinessException("BizError", "something happened");
    }
}