using Microsoft.AspNetCore.Mvc;

namespace GrpcWebApi.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("/test")]
    public IActionResult Get()
    {
        return Ok("TEST");
    }
}