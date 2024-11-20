using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class ShoppingList : BaseEntity
{
    public required string UserId { get; set; }

    [MaxLength(ShoppingListNameMaxLength)]
    public string? Name { get; set; }

    public virtual ICollection<ShoppingListRecipeIngredient> ShoppingListRecipeIngredients { get; set; } = new List<ShoppingListRecipeIngredient>();
}
