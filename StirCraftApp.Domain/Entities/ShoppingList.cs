using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class ShoppingList : BaseEntity
{
    public required string UserId { get; set; }

    [MaxLength(ShoppingListNameMaxLength)]
    public string? Name { get; set; }
}
