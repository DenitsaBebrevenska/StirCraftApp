namespace StirCraftApp.Application.DTOs.ReplyDtos;

/// <summary>
/// Data transfer object for reply of a comment
/// </summary>
public class CommentReplyDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the reply
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The identifier of the user that submitted the reply
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// The Display name of the user that submitted the reply
    /// </summary>
    public required string UserDisplayName { get; set; }

    /// <summary>
    /// The body of the reply
    /// </summary>
    public required string Body { get; set; }

    /// <summary>
    /// The date and time UTC the reply was created
    /// </summary>
    public required string CreatedOn { get; set; }

    /// <summary>
    /// The date and time UTC of the reply when was last edited
    /// </summary>
    public string? UpdatedOn { get; set; }
}
