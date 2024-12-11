using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a recipe entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class Recipe : BaseEntity
{
    /// <summary>
    /// The name of the recipe
    /// </summary>
    [MaxLength(RecipeNameMaxLength)]
    public required string Name { get; set; }

    /// <summary>
    /// Description on how to prepare the recipe
    /// </summary>
    [MaxLength(RecipeDescriptionMaxLength)]
    public required string PreparationSteps { get; set; }

    /// <summary>
    /// Difficulty level of the recipe as enum
    /// </summary>
    public DifficultyLevel DifficultyLevel { get; set; }

    /// <summary>
    /// The unique identifier of the cook that created the recipe
    /// </summary>
    [ForeignKey(nameof(Cook))]
    public int CookId { get; set; }

    /// <summary>
    /// A navigational property to the Cook that created the recipe
    /// </summary>
    public virtual Cook Cook { get; set; } = null!;

    /// <summary>
    /// The date and time UTC the recipe was created on
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The date and time UTC when the recipe was last updated on
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// A flag indicating if the recipe is approved by an admin
    /// </summary>
    public bool IsAdminApproved { get; set; }

    /// <summary>
    /// Any notes an admin has made regarding the recipe if any
    /// </summary>
    [MaxLength(RecipeAdminNotesMaxLength)]
    public string? AdminNotes { get; set; }

    /// <summary>
    /// A collection of recipe ingredients 
    /// </summary>
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    /// <summary>
    /// A collection of user ratings this recipe has received
    /// </summary>
    public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new List<RecipeRating>();

    /// <summary>
    /// A collection of images the creator has associated with the recipe
    /// </summary>
    public virtual ICollection<RecipeImage> RecipeImages { get; set; } = new List<RecipeImage>();

    /// <summary>
    /// A collection of comments made to the recipe
    /// </summary>
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    /// <summary>
    /// A collection of categories to which the recipe belongs to 
    /// </summary>
    public virtual ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();

    /// <summary>
    /// A collection of user favorite recipes in which the current recipe is being favorited 
    /// </summary>
    public virtual ICollection<UserFavoriteRecipe> UserFavoriteRecipes { get; set; } = new List<UserFavoriteRecipe>();
}
