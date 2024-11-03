namespace StirCraftApp.Application.DTOs;
public class RecipeCommentDto
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }

    public ICollection<CommentReplyDto> Replies { get; set; } = [];
}
