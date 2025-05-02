using System;
using System.Collections.Generic;

namespace WebApplication1.Data.Entities;

public partial class RecipeIngredient
{
    public int RecipeId { get; set; }

    public string IngredientName { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string Unit { get; set; } = null!;
}
