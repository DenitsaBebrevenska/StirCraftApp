namespace StirCraftApp.Application.DTOs.Recipe.Reply;
public class CommentReplyDto
{
    public int Id { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }
}
