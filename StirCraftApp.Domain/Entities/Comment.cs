using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;
public sealed class Comment : BaseEntity, ISoftDeletable
{
	public int UserId { get; set; }

	public int RecipeId { get; set; }

	public required string Title { get; set; }

	public required string Body { get; set; }
	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}
