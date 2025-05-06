using System;
using System.Collections.Generic;

namespace AntiAge.Data.Entities;

public partial class BioAgeFactor
{
    public int FactorId { get; set; }

    public string FactorName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal? WeightCoefficient { get; set; }

    public string UnitOfMeasure { get; set; } = null!;

    public decimal? OptimalRangeMin { get; set; }

    public decimal? OptimalRangeMax { get; set; }
}
