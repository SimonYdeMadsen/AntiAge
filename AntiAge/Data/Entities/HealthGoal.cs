using AntiAge.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AntiAge.Data.Entities;

public partial class HealthGoal
{
    public int GoalId { get; set; }

    public int UserId { get; set; }

    public string GoalType { get; set; }

    public decimal TargetValue { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly TargetDate { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }


    // Navigation property to IdentityUser (optional)
    public virtual User User { get; set; }
}
