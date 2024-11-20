using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class RecipeImage : BaseEntity
{
    [MaxLength(ImageUrlMaxLength)]
    public required string Url { get; set; }

    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
