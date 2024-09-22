namespace StirCraftApp.Domain.Entities;
public class FavoriteRecipe : BaseEntity
{
	public int UserId { get; set; }

	public int RecipeId { get; set; }
}
