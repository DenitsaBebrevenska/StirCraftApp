namespace StirCraftApp.Domain.Entities;
public class RecipeRating : BaseEntity
{
	public int Value { get; set; }

	public int RecipeId { get; set; }

	public virtual Recipe Recipe { get; set; } = null!;
	public required string UserId { get; set; }
}
