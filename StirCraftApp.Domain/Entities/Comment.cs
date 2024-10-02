using StirCraftApp.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public sealed class Comment : BaseEntity, ISoftDeletable
{
	public int UserId { get; set; }

	public int RecipeId { get; set; }

	[MaxLength(CommentTitleMaxLength)]
	public required string Title { get; set; }

	[MaxLength(CommentBodyMaxLength)]
	public required string Body { get; set; }
	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}
