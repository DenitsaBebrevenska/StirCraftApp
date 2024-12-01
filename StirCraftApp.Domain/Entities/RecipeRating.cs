using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Domain.Entities;

public class RecipeRating : BaseEntity
{
    public int Value { get; set; }

    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    [ForeignKey(nameof(AppUser))]
    public required string UserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;
}

