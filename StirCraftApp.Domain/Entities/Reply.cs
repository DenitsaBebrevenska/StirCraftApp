using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a reply entity to a comment of a recipe
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class Reply : BaseEntity
{
    /// <summary>
    /// The unique identifier of the user that replied to the comment
    /// </summary>
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    /// <summary>
    /// A navigational property to the user that replied to the comment
    /// </summary>
    public virtual AppUser AppUser { get; set; } = null!;

    /// <summary>
    /// The unique identifier of the comment that this reply belongs to
    /// </summary>
    [ForeignKey(nameof(Comment))]
    public int CommentId { get; set; }

    /// <summary>
    /// A navigational property to the comment that this reply belongs to
    /// </summary>
    public virtual Comment Comment { get; set; } = null!;

    /// <summary>
    /// The body of the reply
    /// </summary>
    [MaxLength(ReplyBodyMaxLength)]
    public required string Body { get; set; }

    /// <summary>
    /// The date and time UTC this reply has been created
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The date and time UTC this reply has been last edited if any
    /// </summary>
    public DateTime? UpdatedOn { get; set; }
}
