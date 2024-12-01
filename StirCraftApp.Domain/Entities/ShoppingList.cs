using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class ShoppingList : BaseEntity
{
    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;

    [MaxLength(ShoppingListNameMaxLength)]
    public string? Name { get; set; }

    public virtual ICollection<ShoppingListRecipeIngredient> ShoppingListRecipeIngredients { get; set; } = new List<ShoppingListRecipeIngredient>();
}
