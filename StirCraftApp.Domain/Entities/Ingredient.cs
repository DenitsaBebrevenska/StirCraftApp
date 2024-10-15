﻿using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Ingredient : BaseEntity
{
	[MaxLength(IngredientNameMaxLength)]
	public required string Name { get; set; }

	public bool IsAllergen { get; set; }

	[MaxLength(IngredientPluralNameMaxLength)]
	public string? NameInPlural { get; set; }

	public bool IsSolid { get; set; }

	public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
