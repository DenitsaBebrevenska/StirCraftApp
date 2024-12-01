using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface IRecipeService
{
    //todo object should be replaced with a dto probably marker base class
    Task<object> GetRecipeByIdAsync(ISpecification<Recipe>? spec, int id, string dtoName);
    Task<PaginatedResult> GetRecipesAsync(ISpecification<Recipe> spec, string dtoName);
    Task<IEnumerable<object>> GetTopNRecipes(int count, string dtoName);
    Task CreateRecipeAsync(FormRecipeDto createRecipeDto, int cookId);
    Task UpdateRecipeAsync(EditFormRecipeDto updateRecipeDto);
    Task DeleteRecipeAsync(int id);
    Task<bool> ToggleFavoriteAsync(string userId, int recipeId);
}

