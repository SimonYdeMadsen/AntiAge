using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/home")]
public class IndexController : ControllerBase
{
    [HttpGet]
    public IActionResult GetWelcomeMessage()
    {
        return Ok(new { message = "Welcome to our API!", status = "Running" });
    }  
}