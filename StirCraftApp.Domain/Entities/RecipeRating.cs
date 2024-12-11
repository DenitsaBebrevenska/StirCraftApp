using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a recipe rating entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class RecipeRating : BaseEntity
{
    /// <summary>
    /// The value of the rating 1-5
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// The identifier of the recipe that has received the rating
    /// </summary>
    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    /// <summary>
    /// A navigational property to the recipe that has received the rating
    /// </summary>
    public virtual Recipe Recipe { get; set; } = null!;

    /// <summary>
    /// The unique identifier of the user that gave the rating
    /// </summary>
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    /// <summary>
    /// A navigational property to the user that gave the rating
    /// </summary>
    public virtual AppUser AppUser { get; set; } = null!;
}

