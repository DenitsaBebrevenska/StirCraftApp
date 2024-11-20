using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Category : BaseEntity
{
    [MaxLength(CategoryMaxLength)]
    public required string Name { get; set; }

    public virtual ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();
}
