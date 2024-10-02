using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Recipe : BaseEntity, ISoftDeletable
{
	[MaxLength(RecipeNameMaxLength)]
	public required string Name { get; set; }

	[MaxLength(RecipeDescriptionMaxLength)]
	public required string Description { get; set; }

	public uint Likes { get; set; }

	public DifficultyLevel DifficultyLevel { get; set; }

	public int CookId { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime UpdatedOn { get; set; }

	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }

	public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
	public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new List<RecipeRating>();

	public virtual ICollection<RecipeImage> RecipeImages { get; set; } = new List<RecipeImage>();

	public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
