using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.ReplyDtos;


namespace StirCraftApp.Application.DTOs.CommentDtos;
public class RecipeCommentDto : IDto
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string UserId { get; set; }

    public required string UserDisplayName { get; set; }

    public required string Body { get; set; }

    public required string CreatedOn { get; set; }

    public string? UpdatedOn { get; set; }

    public ICollection<CommentReplyDto> Replies { get; set; } = [];
}
