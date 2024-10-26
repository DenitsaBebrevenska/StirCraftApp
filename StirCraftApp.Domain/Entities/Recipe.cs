using StirCraftApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Domain.Entities;
public class Recipe : BaseEntity
{
    [MaxLength(RecipeNameMaxLength)]
    public required string Name { get; set; }

    [MaxLength(RecipeDescriptionMaxLength)]
    public required string PreparationSteps { get; set; }

    public DifficultyLevel DifficultyLevel { get; set; }

    public int CookId { get; set; }

    public virtual Cook Cook { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public bool IsAdminApproved { get; set; }

    [MaxLength(RecipeAdminNotesMaxLength)]
    public string? AdminNotes { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new List<RecipeRating>();

    public virtual ICollection<RecipeImage> RecipeImages { get; set; } = new List<RecipeImage>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
