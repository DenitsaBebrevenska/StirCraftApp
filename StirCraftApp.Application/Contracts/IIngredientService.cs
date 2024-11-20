using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Application.Contracts;
public interface IIngredientService
{
    Task<DetailedIngredientDto> GetIngredientByIdAsync(int id);
    Task<PaginatedResult> GetIngredientsAsync(BaseSpecification<Ingredient> spec);

    Task SuggestIngredient(SuggestIngredientDto ingredient);

    Task CreateIngredientAsync(FormIngredientDto ingredient);

    Task UpdateIngredientAsync(FormIngredientDto ingredient, int id);

    Task DeleteIngredientAsync(int id);

}
