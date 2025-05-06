using System;
using System.Collections.Generic;

namespace AntiAge.Data.Entities;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string ExerciseName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string MuscleGroup { get; set; } = null!;

    public string EquipmentNeeded { get; set; } = null!;

    public string DifficultyLevel { get; set; } = null!;

    public string DemoVideoUrl { get; set; } = null!;
}
