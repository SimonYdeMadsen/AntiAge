using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AntiAge.Data;
using AntiAge.Data.Identity;
using AntiAge.Shared.Dtos;

namespace AntiAge.Controllers;

[Authorize]
[ApiController]
[Route("user")]
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

    [HttpGet("healthmetrics/count")]
    public async Task<ActionResult<int>> GetUserHealthMetricsCount()
    {
        var user = GetUserFromClaims();
        if (user is null) return Unauthorized();

        int count = await _context.HealthMetrics
            .Where(m => m.UserId == user.Id)
            .CountAsync();

        return count;
    }

   [HttpGet("healthmetrics")]
    public async Task<ActionResult<HealthMetricDto>> GetUserHealthMetrics(int page = 1, int pageSize = 20)
    {

        var user = GetUserFromClaims();
        if (user is null) return Unauthorized();

        int pagesToSkip = (page-1) * pageSize;
        
        var healthMetrics = await _context.HealthMetrics
            .Where(m => m.UserId == user.Id)
            .OrderBy(m => m.UserId)
            .Skip(pagesToSkip)
            .Take(pageSize)
            .Select(m => new HealthMetricDto
            {
                BiologicalAge = m.BiologicalAge,
                Bmi = m.Bmi,
                DateRecorded = m.DateRecorded,
                WeightKg = m.WeightKg,
                BodyFatPercentage = m.BodyFatPercentage,
                BloodPressureSystolic = m.BloodPressureSystolic,
                BloodPressureDiastolic = m.BloodPressureDiastolic,
                RestingHeartRate = m.RestingHeartRate,
                BloodGlucose = m.BloodGlucose,
                HdlCholesterol = m.HdlCholesterol,
                LdlCholesterol = m.LdlCholesterol,
                Triglycerides = m.Triglycerides,
                Vo2Max = m.Vo2Max,
                SleepHours = m.SleepHours,
                StepsCount = m.StepsCount
            }).ToListAsync();
        return healthMetrics.Any() ? Ok(healthMetrics) : NotFound($"No health metrics found for ID {user.Id}");
    }


    private User? GetUserFromClaims()
    {
        string? userStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userStr) || !int.TryParse(userStr, out int userId))
        {
            _logger.LogError(new KeyNotFoundException(), "No user ID found in token");
            return null;
        }

        User? user = _context.Users.SingleOrDefault(u => u.Id == userId);
        if (user is null)
        {
            _logger.LogError(new KeyNotFoundException($"No user registered for {userId}"), $"No user registered for {userId}");
            return null;
        }

        return user;
    }
}