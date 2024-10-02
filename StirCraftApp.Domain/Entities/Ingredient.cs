using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Ingredient : BaseEntity
{
	[MaxLength(IngredientNameMaxLength)]
	public required string Name { get; set; }

	public bool IsAllergen { get; set; }

	public bool IsVegan { get; set; }

	public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
