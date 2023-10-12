using Microsoft.AspNetCore.Mvc;

namespace HandleErrors01.Controllers;


[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromServices] IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment.IsDevelopment())
            throw new HttpResponseException(400, "foobar");
        else
            throw new Exception("release");
    }
}