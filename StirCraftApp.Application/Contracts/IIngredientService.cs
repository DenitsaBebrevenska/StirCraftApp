using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface IIngredientService
{
    Task<DetailedIngredientDto> GetIngredientByIdAsync(int id);
    Task<PaginatedResult> GetIngredientsAsync(ISpecification<Ingredient> spec);

    Task SuggestIngredient(SuggestIngredientDto ingredient);

    Task CreateIngredientAsync(FormIngredientDto ingredient);

    Task UpdateIngredientAsync(FormIngredientDto ingredient, int id);

    Task DeleteIngredientAsync(int id);

}
