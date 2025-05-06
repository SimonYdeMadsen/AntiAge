using Microsoft.AspNetCore.Mvc;
using AntiAge.Controllers.Dto;

namespace AntiAge.Controllers;

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