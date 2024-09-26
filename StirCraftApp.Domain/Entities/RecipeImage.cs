using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;
public class RecipeImage : BaseEntity, ISoftDeletable
{
	public required string Url { get; set; }

	public int RecipeId { get; set; }

	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}
