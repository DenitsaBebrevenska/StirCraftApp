namespace StirCraftApp.Domain.Entities;
public class RecipeRating : BaseEntity
{
	public int Value { get; set; }

	public int RecipeId { get; set; }

	public virtual required Recipe Recipe { get; set; }
	public required string UserId { get; set; }
}
