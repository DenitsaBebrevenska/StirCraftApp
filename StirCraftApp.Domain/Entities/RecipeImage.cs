namespace StirCraftApp.Domain.Entities;
public class RecipeImage : BaseEntity
{
	public required string Url { get; set; }

	public int RecipeId { get; set; }
}
