//using System.Security.Claims;
//using System.Text;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication1.Controllers.Dto;
//using WebApplication1.Data;
//using WebApplication1.Data.Entities;

//namespace WebApplication1.Controllers;

//[ApiController]
//[Route("api/users")]
//public class UserController : ControllerBase
//{
//    private readonly ApplicationDbContext _context;
//    private readonly UserManager<User> _userManager;
//    private readonly RoleManager<IdentityRole<int>> _roleManager;

//    public UserController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
//    {
//        _context = context;
//        _userManager = userManager;
//        _roleManager = roleManager;
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateUser(string name, string userName, string email, string password, string role = null)
//    {
//        // Check if the user already exists
//        var existingUser = await _userManager.FindByEmailAsync(email);
//        if (existingUser != null)
//        {
//            return BadRequest("User with this email already exists.");
//        }

//        // Create new user object
//        var user = new User
//        {
//            //Name = name,
//            //Password = password,
//            UserName = userName,
//            Email = email
//        };

//        // Create the user with the provided password
//        var result = await _userManager.CreateAsync(user, password);

//        if (!result.Succeeded)
//        {
//            // If user creation fails, return an error
//            return BadRequest(result.Errors);
//        }

//        // If a role was provided, assign the role to the user
//        if (!string.IsNullOrEmpty(role))
//        {
//            var roleExists = await _roleManager.RoleExistsAsync(role);
//            if (!roleExists)
//            {
//                return BadRequest("Role does not exist.");
//            }

//            var addRoleResult = await _userManager.AddToRoleAsync(user, role);
//            if (!addRoleResult.Succeeded)
//            {
//                return BadRequest("Failed to assign role.");
//            }
//        }

//        // Return success message
//        return Ok("User created successfully.");
//    }

//    [HttpPost("login")]
//    public IActionResult Login(LoginDto login)
//    {
//        //// Return cookie?? Somehow create a session that is secure and only allow access to certain endpoints
//        //if (!context.Users.Any(u => u.Mail == login.Mail))
//        //{
//        //    return Unauthorized("Invalid username");
//        //}
//        //var user = context.Users.First(u => u.Mail == login.Mail && u.Password == login.Password);
//        //if (user != null)
//        //{
//        //    var token = GenerateJwtToken(user);
//        //    return Ok(new { token });
//        //}
//        return Unauthorized("Invalid password");
//    }

//    //private string GenerateJwtToken(User user)
//    //{
//    //    var claims = new[] 
//    //    {
//    //        new Claim(ClaimTypes.Name, user.Name),
//    //        new Claim(ClaimTypes.Email, user.Mail),
//    //    };

//    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourVeryLongSecretKey1234567890123456")); // 256 bits
//    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//    //    var token = new JwtSecurityToken(
//    //        issuer: "yourdomain.com",
//    //        audience: "yourdomain.com",
//    //        claims: claims,
//    //        expires: DateTime.Now.AddDays(1),
//    //        signingCredentials: creds
//    //    );

//    //    return new JwtSecurityTokenHandler().WriteToken(token);
//    //}

//    [HttpGet("biomarkers")]
//    [Authorize]
//    public ActionResult<List<BioMarkerDto>> GetAllBioMarkersForUser()
//    {
//        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

//        return userEmail != null ? Ok(new { userEmail }) : Unauthorized("Email null");

//        //return context.BioMarkers
//        //    .Where(b => b.UsersBioMarkers.Any(ub => ub.User.Mail == mail))
//        //    .Select(b => new BioMarkerDto
//        //    {
//        //        Id = b.Id,
//        //        Name = b.Name,
//        //        Description = b.Description
//        //    })
//        //    .ToList();
//    }
//}