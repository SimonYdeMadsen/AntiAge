using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AntiAge.Controllers.Dto;
using AntiAge.Data;
using AntiAge.Data.Identity;
using AntiAge.Shared.Dtos;

namespace AntiAge.Controllers;

[ApiController]
[Route("Users")]
public class UserController : ControllerBase
{
    private readonly AntiAgeContext _context;
    private readonly UserManager<User> _userManager;
    //private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserController> _logger;

    public UserController(AntiAgeContext context, UserManager<User> userManager, IConfiguration configuration, ILogger<UserController> logger)
    {
        _context = context;
        _userManager = userManager;
        //_roleManager = roleManager;
        _configuration = configuration;
        _logger = logger;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return new UserDto { Email = user.Email , UserId = user.Id };
    }


    [HttpGet("viewUsers")]
    public IActionResult ViewUsers()
    {
        // Return cookie?? Somehow create a session that is secure and only allow access to certain endpoints
        if (!_context.Users.Any())
        {
            return Unauthorized("No users");
        }
        var users = _context.Users.ToList();

        return users.Count > 0? Ok(users) : NotFound("No users");
        
    }


    [Authorize]
    [HttpGet("getUserHealthMetrics")]
    public async Task<ActionResult<HealthMetricDto>> GetUserHealthMetrics()
    {

        string? userStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userStr) || !int.TryParse(userStr, out int userId))
        {
            return Unauthorized("No user ID found in token");
        }

        User? user = _context.Users.SingleOrDefault(u => u.Id == userId);
        if (user is null)
        {
            return NotFound($"No user registered for {userId}");
        }

        var healthMetrics = await _context.HealthMetrics
            .Where(m => m.UserId == userId)
            .Select(m => new HealthMetricDto
            {
                UserId = userId,
                BiologicalAge = m.BiologicalAge,
                Bmi = m.Bmi,
            }).ToListAsync();
        return healthMetrics.Any() ? Ok(healthMetrics) : NotFound($"No health metrics found for ID {user.Id}");
    }
}