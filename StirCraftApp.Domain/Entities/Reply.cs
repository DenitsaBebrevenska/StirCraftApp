using StirCraftApp.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Reply : BaseEntity, ISoftDeletable
{
	public int UserId { get; set; }

	public int CommentId { get; set; }

	[MaxLength(ReplyBodyMaxLength)]
	public required string Body { get; set; }

	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}
