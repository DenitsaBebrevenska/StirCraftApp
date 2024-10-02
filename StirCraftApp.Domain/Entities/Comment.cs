using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Comment : BaseEntity
{
	public required string UserId { get; set; }

	public int RecipeId { get; set; }

	[MaxLength(CommentTitleMaxLength)]
	public required string Title { get; set; }

	[MaxLength(CommentBodyMaxLength)]
	public required string Body { get; set; }
	public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
}
