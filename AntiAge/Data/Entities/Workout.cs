using System;
using System.Collections.Generic;

namespace AntiAge.Data.Entities;

public partial class Workout
{
    public int WorkoutId { get; set; }

    public int? ProgramId { get; set; }

    public string WorkoutName { get; set; } = null!;

    public int? WeekNumber { get; set; }

    public int? DayNumber { get; set; }

    public int? EstimatedDuration { get; set; }

    public string? Instructions { get; set; }

    public virtual WorkoutsProgram WorkoutsProgram { get; set; } = null!;
}
