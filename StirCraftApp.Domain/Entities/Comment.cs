using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a comment entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class Comment : BaseEntity
{
    /// <summary>
    /// The unique identifier for the user that made the comment
    /// </summary>
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    /// <summary>
    /// A navigational property to the user that made the comment
    /// </summary>
    public virtual AppUser AppUser { get; set; } = null!;

    /// <summary>
    /// The unique identifier for the recipe that the comment is made on
    /// </summary>
    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    /// <summary>
    /// A navigational property to the recipe that the comment is made on
    /// </summary>
    public virtual Recipe Recipe { get; set; } = null!;

    /// <summary>
    /// The title of the comment
    /// </summary>
    [MaxLength(CommentTitleMaxLength)]
    public required string Title { get; set; }

    /// <summary>
    /// The body of the comment
    /// </summary>
    [MaxLength(CommentBodyMaxLength)]
    public required string Body { get; set; }

    /// <summary>
    /// The date and time UTC when the comment was created
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The date and time UTC when the comment was last updated if any  
    /// </summary>
    public DateTime? UpdatedOn { get; set; }

    /// <summary>
    /// A collection of replies that are made on this comment 
    /// </summary>
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
}
