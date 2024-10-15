using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Reply : BaseEntity
{
	public required string UserId { get; set; }

	public int CommentId { get; set; }

	public virtual required Comment Comment { get; set; }

	[MaxLength(ReplyBodyMaxLength)]
	public required string Body { get; set; }
}
