using Microsoft.AspNetCore.Identity;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Infrastructure.Data.JoinedTables;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Infrastructure.Identity;
public class AppUser : IdentityUser, ISoftDeletable
{
    [MaxLength(UserDisplayNameMaxLength)]
    public string? DisplayName { get; set; }

    [MaxLength(ImageUrlMaxLength)]
    public string? AvatarUrl { get; set; }
    public virtual ICollection<UserFavoriteRecipe> FavoriteRecipes { get; set; } = new List<UserFavoriteRecipe>();

    public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();

    public virtual ICollection<RecipeRating> RecipesRatings { get; set; } = new List<RecipeRating>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}
