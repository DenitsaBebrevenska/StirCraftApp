using StirCraftApp.Application.DTOs.Recipe;
using StirCraftApp.Domain.Specifications;

namespace StirCraftApp.Application.Contracts;
public interface IRecipeService
{
    Task<DetailedRecipeDto> GetRecipeByIdAsync(int id);
    Task<PaginatedResult<SummaryRecipeDto>> GetRecipesAsync(RecipeFilterSortIncludeSpecification spec);
    Task<IEnumerable<SummaryRecipeDto>> GetTopThreeRecipes();
    Task CreateRecipeAsync(FormRecipeDto createRecipeDto);
    Task UpdateRecipeAsync(FormRecipeDto updateRecipeDto);
    Task DeleteRecipeAsync(int id);
}
