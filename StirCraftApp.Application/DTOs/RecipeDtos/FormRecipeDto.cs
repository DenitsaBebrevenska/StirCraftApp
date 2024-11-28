using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Application.DTOs.RecipeDtos.Image;
using StirCraftApp.Application.DTOs.RecipeDtos.Ingredient;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class FormRecipeDto : IDto
{
    public required string Name { get; set; }

    public required string PreparationSteps { get; set; }

    public required string DifficultyLevel { get; set; }

    public IList<FormRecipeIngredientDto> RecipeIngredients { get; set; } = [];

    public IList<RecipeImageDto> RecipeImages { get; set; } = [];

    public IList<CategoryDto> CategoryRecipes { get; set; } = [];


}
