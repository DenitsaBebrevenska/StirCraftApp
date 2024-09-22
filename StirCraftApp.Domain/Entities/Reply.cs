namespace StirCraftApp.Domain.Entities;
public class Reply : BaseEntity
{
	public int UserId { get; set; }

	public int CommentId { get; set; }

	public required string Body { get; set; }
}
