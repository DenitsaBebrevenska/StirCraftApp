namespace StirCraftApp.Domain.Entities;
public class Comment : BaseEntity
{
	public int UserId { get; set; }

	public int RecipeId { get; set; }

	public required string Title { get; set; }

	public required string Body { get; set; }
}
