namespace StirCraftApp.Domain.Entities;
public class RecipeRating : BaseEntity
{
	public int Value { get; set; }

	public int RecipeId { get; set; }

	public int UserId { get; set; }
}
