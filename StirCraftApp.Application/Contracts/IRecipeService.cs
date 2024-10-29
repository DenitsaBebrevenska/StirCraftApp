using StirCraftApp.Application.DTOs;
using StirCraftApp.Domain.Specifications;

namespace StirCraftApp.Application.Contracts;
public interface IRecipeService
{
    Task<IEnumerable<QuickViewRecipeDto>> GetRecipesAsync(RecipeSpecification specParams);
}
