﻿using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class MeasurementUnit : BaseEntity
{
    [MaxLength(UnitNameMaxLength)]
    public required string Name { get; set; }

    [MaxLength(UnitAbbreviationMaxLength)]
    public required string Abbreviation { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
