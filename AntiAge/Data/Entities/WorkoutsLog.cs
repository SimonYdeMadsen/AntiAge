using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class WorkoutsLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public int? WorkoutId { get; set; }

    public DateOnly? DateCompleted { get; set; }

    public int? DurationMinutes { get; set; }

    public int? PerceivedEffort { get; set; }

    public string? Notes { get; set; }
}
