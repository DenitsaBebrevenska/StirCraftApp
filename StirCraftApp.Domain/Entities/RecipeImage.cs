using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class RecipeImage : BaseEntity
{
    [MaxLength(ImageUrlMaxLength)]
    public required string Url { get; set; }

    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
