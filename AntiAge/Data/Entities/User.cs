using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public class User : IdentityUser<int>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public short? HeightCm { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }
}
