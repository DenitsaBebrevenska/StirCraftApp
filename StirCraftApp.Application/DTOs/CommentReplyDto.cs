namespace StirCraftApp.Application.DTOs;
public class CommentReplyDto
{
    public int Id { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }
}
