using StirCraftApp.Application.Common;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface IIngredientService
{
    Task<EditFormIngredientDto> GetIngredientByIdAsync(int id, ISpecification<Ingredient>? spec);
    Task<PaginatedResult> GetIngredientsAsync(ISpecification<Ingredient>? spec, string dtoName);

    Task<IList<BriefIngredientDto>> GetIngredientsNotPaged();

    Task SuggestIngredient(SuggestIngredientDto ingredient);

    Task CreateIngredientAsync(FormIngredientDto ingredient);

    Task UpdateIngredientAsync(EditFormIngredientDto ingredientDto, int id);

    Task DeleteIngredientAsync(int id);

}
