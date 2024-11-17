using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos.Reply;

namespace StirCraftApp.Application.DTOs.RecipeDtos.Comment;
public class RecipeCommentDto : IDto
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }

    public ICollection<CommentReplyDto> Replies { get; set; } = [];
}
