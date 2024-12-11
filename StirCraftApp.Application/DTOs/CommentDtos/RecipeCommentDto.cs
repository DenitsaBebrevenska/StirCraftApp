using StirCraftApp.Application.DTOs.ReplyDtos;


namespace StirCraftApp.Application.DTOs.CommentDtos;

/// <summary>
/// Represents a recipe comment data transfer object.
/// </summary>
public class RecipeCommentDto : BaseDto
{
    /// <summary>
    /// Unique identifier of the comment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the comment.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// User identifier who created the comment.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// The display name of the user who created the comment.
    /// </summary>
    public required string UserDisplayName { get; set; }

    /// <summary>
    /// The body of the comment.
    /// </summary>
    public required string Body { get; set; }

    /// <summary>
    /// The date and time UTC when the comment was created.
    /// </summary>
    public required string CreatedOn { get; set; }

    /// <summary>
    /// The date and time UTC when the comment was last updated if at all was updated.
    /// </summary>
    public string? UpdatedOn { get; set; }

    /// <summary>
    /// The replies to the comment.
    /// </summary>
    public ICollection<CommentReplyDto> Replies { get; set; } = [];
}
