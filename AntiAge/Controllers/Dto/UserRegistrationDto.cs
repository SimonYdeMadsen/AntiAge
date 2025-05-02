namespace WebApplication1.Controllers.Dto;

public class UserRegistrationDto
{
    public required string Name { get; set; }
    public required string Mail { get; set; }
    public required string Password { get; set; }
}