using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface IIngredientService
{
    Task<T> GetIngredientByIdAsync<T>(int id, ISpecification<Ingredient>? spec, Func<Ingredient, T> convertToDto) where T : BaseDto;
    Task<PaginatedResult<T>> GetIngredientsAsync<T>(ISpecification<Ingredient> spec, Func<Ingredient, T> convertToDto) where T : BaseDto;

    Task<IList<BriefIngredientDto>> GetIngredientsNotPaged();

    Task SuggestIngredient(SuggestIngredientDto ingredient);

    Task<EditFormIngredientDto> CreateIngredientAsync(FormIngredientDto ingredientDto);

    Task UpdateIngredientAsync(EditFormIngredientDto ingredientDto, int id);

    Task DeleteIngredientAsync(int id);

}
