using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Domain.Entities;
public class Reply : BaseEntity, ISoftDeletable
{
	public int UserId { get; set; }

	public int CommentId { get; set; }

	public required string Body { get; set; }

	public bool IsDeleted { get; set; }
	public int IsDeletedBy { get; set; }
}
