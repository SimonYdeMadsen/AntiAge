using AntiAge.Api.Data;
using AntiAge.Data;
using AntiAge.Data.Identity;
using AntiAge.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AntiAge.Controllers;

[Authorize]
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;
    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;
    private readonly ILogger<UserController> logger;

    public UserController(IUserRepository userRepository, UserManager<User> userManager, IConfiguration configuration, ILogger<UserController> logger)
    {
        this.userRepository = userRepository;
        this.userManager = userManager;
        this.configuration = configuration;
        this.logger = logger;
    }

    [HttpGet("healthmetrics/count")]
    public async Task<ActionResult<int>> GetUserHealthMetricsCount()
    {
        int userId = GetUserIdFromClaims();
        User user = await userRepository.GetUser(userId);
        if (user == null) return Unauthorized();

        int count = await userRepository.GetUserHealthMetricsCount(user.Id);
        return Ok(count);
    }

   [HttpGet("healthmetrics")]
    public async Task<ActionResult<HealthMetricDto>> GetUserHealthMetrics(int page = 1, int pageSize = 20)
    {

        int userId = GetUserIdFromClaims();

        User user = await userRepository.GetUser(userId);


        if (user is null) return Unauthorized();
        
        var healthMetrics = await userRepository.GetUserHealthMetrics(page, pageSize, user.Id);

        return healthMetrics.Any() ? Ok(healthMetrics) : NotFound($"No health metrics found for ID {user.Id}");
    }


    private int GetUserIdFromClaims()
    {
        string? userStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userStr) || !int.TryParse(userStr, out int userId))
        {
            logger.LogError(new KeyNotFoundException(), "No user ID found in token");
            return -1;
        }
        return userId;

    }
}