
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.JoinedTables;

public class UserFavoriteRecipe
{
    public required string UserId { get; set; }

    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
