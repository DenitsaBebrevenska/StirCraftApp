using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.JoinedTables;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class FormRecipeDto : IDto
{
    public required string Name { get; set; }

    public required string PreparationSteps { get; set; }

    public int DifficultyLevel { get; set; }

    public int CookId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public bool IsAdminApproved { get; set; }

    public string? AdminNotes { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeImage> RecipeImages { get; set; } = new List<RecipeImage>();

    public virtual ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();


}
