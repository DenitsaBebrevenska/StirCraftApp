using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Application.Contracts;
public interface IRecipeService
{
    Task<object> GetRecipeByIdAsync(int id, string dtoName);
    Task<PaginatedResult> GetRecipesAsync(BaseSpecification<Recipe> spec, string dtoName);
    Task<IEnumerable<object>> GetTopThreeRecipes(string dtoName);
    Task CreateRecipeAsync(FormRecipeDto createRecipeDto);
    Task UpdateRecipeAsync(FormRecipeDto updateRecipeDto);
    Task DeleteRecipeAsync(int id);
}

