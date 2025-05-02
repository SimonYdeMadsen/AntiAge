using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? PreparationTime { get; set; }

    public decimal? CookingTime { get; set; }

    public decimal? Servings { get; set; }

    public decimal? CaloriesPerServing { get; set; }

    public decimal? ProteinGrams { get; set; }

    public decimal? CarbsGrams { get; set; }

    public decimal? FatGrams { get; set; }

    public string RecipeCategory { get; set; } = null!;

    public string? Instructions { get; set; }

    public string? ImageUrl { get; set; }
}
