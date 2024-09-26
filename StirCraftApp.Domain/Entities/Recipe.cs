using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Enums;

namespace StirCraftApp.Domain.Entities;
public class Recipe : BaseEntity, ISoftDeletable
{
	public required string Name { get; set; }

	public required string Description { get; set; }

	public int Likes { get; set; }

	public DifficultyLevel DifficultyLevel { get; set; }

	public int CategoryId { get; set; }

	public int CookId { get; set; }

	public DateTime CreatedOn { get; set; }

	public DateTime UpdatedOn { get; set; }

	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}
