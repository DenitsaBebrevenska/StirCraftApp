using Microsoft.AspNetCore.Identity;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a user in the application.
/// Implements ISoftDeletable interface and inherits from IdentityUser.
/// </summary>
public class AppUser : IdentityUser, ISoftDeletable
{
    /// <summary>
    /// The Display name of the user
    /// </summary>
    [MaxLength(UserDisplayNameMaxLength)]
    public string? DisplayName { get; set; }

    /// <summary>
    /// The Url that points to the user avatar image if any
    /// </summary>
    [MaxLength(ImageUrlMaxLength)]
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// A collection of recipes that are liked by the current user
    /// </summary>
    public virtual ICollection<UserFavoriteRecipe> FavoriteRecipes { get; set; } = new List<UserFavoriteRecipe>();

    /// <summary>
    /// A collection of ratings that the user has given to recipes
    /// </summary>
    public virtual ICollection<RecipeRating> RecipesRatings { get; set; } = new List<RecipeRating>();

    /// <summary>
    /// A collection of comments that the user has made on recipes
    /// </summary>
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    /// <summary>
    /// A collection of replies that the user has made on comments of recipes
    /// </summary>
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();

    /// <summary>
    /// A flag that indicates if the user is deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// The date and time UTC when the user was deleted
    /// </summary>
    public DateTime? DeletedOnUtc { get; set; }
}
