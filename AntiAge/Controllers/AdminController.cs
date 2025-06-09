using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AntiAge.Data;
using AntiAge.Data.Identity;
using AntiAge.Shared.Dtos;

namespace AntiAge.Controllers;


[ApiController]
[Route("users")]
public class Admincontroller : ControllerBase
{
    private readonly AntiAgeContext _context;
    private readonly UserManager<User> _userManager;
    //private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserController> _logger;

    public Admincontroller(AntiAgeContext context, UserManager<User> userManager, IConfiguration configuration, ILogger<UserController> logger)
    {
        _context = context;
        _userManager = userManager;
        //_roleManager = roleManager;
        _configuration = configuration;
        _logger = logger;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<LoginDto>> GetUserLogin(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return new LoginDto { UserId = user.Id, Email = user.Email };
    }


    [HttpGet("all")]
    public IActionResult GetAllUsers()
    {
        var users = _context.Users.ToList();
        if (users.Count <= 0)
        {
            return NotFound("No users");
        }

        return Ok(users);
        
    }
}