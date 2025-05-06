using System;
using System.Collections.Generic;

namespace AntiAge.Data.Entities;

public partial class WorkoutsProgram
{
    public int ProgramId { get; set; }

    public string? ProgramName { get; set; }

    public string? Description { get; set; }

    public string? DifficultyLevel { get; set; }

    public int? DurationWeeks { get; set; }

    public string? FocusArea { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();

    public virtual User? Creator { get; set; }
}
