using StirCraftApp.Domain.Enums;

namespace StirCraftApp.Domain.Entities;
public class Recipe : BaseEntity
{

	public required string Name { get; set; }

	public string Description { get; set; }

	public int Likes { get; set; }

	public DifficultyLevel DifficultyLevel { get; set; }

	public int CategoryId { get; set; }

	public int CookId { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime UpdatedOn { get; set; }
}
