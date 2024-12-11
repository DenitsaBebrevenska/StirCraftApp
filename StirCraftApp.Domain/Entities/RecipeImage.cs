using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a recipe image entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class RecipeImage : BaseEntity
{
    /// <summary>
    /// An url pointing to the image
    /// </summary>
    [MaxLength(ImageUrlMaxLength)]
    public required string Url { get; set; }

    /// <summary>
    /// The unique identifier of the recipe that is image is associated with
    /// </summary>
    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    /// <summary>
    /// A navigational property to the recipe that this image belongs to
    /// </summary>
    public virtual Recipe Recipe { get; set; } = null!;
}
