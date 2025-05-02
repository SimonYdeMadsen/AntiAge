using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class WorkoutExercise
{
    public int WorkoutId { get; set; }

    public int? ExerciseId { get; set; }

    public string Sets { get; set; } = null!;

    public int? Repeats { get; set; }

    public string? RepeatsUnits { get; set; }

    public decimal? RestPeriod { get; set; }

    public string? Notes { get; set; }

    public int? SequenceNumber { get; set; }
}
