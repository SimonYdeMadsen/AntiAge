using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers.Dto;

namespace WebApplication1.Controllers;

[ApiController]
[Route("BioMarker")]
public class BioMarkerController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateBioMarker(UserRegistrationDto user)
    {
        return Ok("MaNigga");
    }
    
    [HttpGet]
    public IActionResult GetAllExistingBioMarkers()
    {
        return Ok("Your mom");
    }
}