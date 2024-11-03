using StirCraftApp.Application.DTOs;
using StirCraftApp.Domain.Specifications;

namespace StirCraftApp.Application.Contracts;
public interface IRecipeService
{
    Task<DetailedRecipeDto> GetRecipeByIdAsync(int id);
    Task<PaginatedResult<SummaryRecipeDto>> GetRecipesAsync(RecipeFilterSortIncludeSpecification specParams);
    Task CreateRecipeAsync(FormRecipeDto createRecipeDto);
    Task UpdateRecipeAsync(FormRecipeDto updateRecipeDto);
    Task DeleteRecipeAsync(int id);
}
