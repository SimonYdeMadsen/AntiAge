using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class HealthMetric
{
    public int MetricId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? DateRecorded { get; set; }

    public decimal? WeightKg { get; set; }

    public decimal? BodyFatPercentage { get; set; }

    public decimal? Bmi { get; set; }

    public decimal? BloodPressureSystolic { get; set; }

    public decimal? BloodPressureDiastolic { get; set; }

    public decimal? RestingHeartRate { get; set; }

    public decimal? BloodGlucose { get; set; }

    public decimal? HdlCholesterol { get; set; }

    public decimal? LdlCholesterol { get; set; }

    public decimal? Triglycerides { get; set; }

    public decimal? Vo2Max { get; set; }

    public decimal? SleepHours { get; set; }

    public int? StepsCount { get; set; }

    public decimal? BiologicalAge { get; set; }
}
