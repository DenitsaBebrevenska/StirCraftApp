using StirCraftApp.Application.DTOs.Recipe.Reply;

namespace StirCraftApp.Application.DTOs.Recipe.Comment;
public class RecipeCommentDto
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }

    public ICollection<CommentReplyDto> Replies { get; set; } = [];
}
