using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;
public class IngredientService(IUnitOfWork unit) : IIngredientService
{
    #region Get Ingredients
    public async Task<T> GetIngredientByIdAsync<T>(int id, ISpecification<Ingredient>? spec, Func<Ingredient, T> convertToDto) where T : BaseDto
    {
        var ingredient = await unit.Repository<Ingredient>()
            .GetByIdAsync(spec, id);

        if (ingredient == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Ingredient), id));
        }

        var ingredientDto = convertToDto(ingredient);

        return ingredientDto;
    }

    public async Task<PaginatedResult<T>> GetIngredientsAsync<T>(ISpecification<Ingredient>? spec, Func<Ingredient, T> convertToDto) where T : BaseDto
    {
        var ingredients = await unit.Repository<Ingredient>()
            .GetAllAsync(spec);

        var count = await unit.Repository<Ingredient>()
            .CountAsync(spec);

        var ingredientDtos = ingredients.Select(convertToDto).ToList();

        var paginatedResult = new PaginatedResult<T>(spec.Skip,
            spec.Take,
            count,
            ingredientDtos);

        return paginatedResult;
    }

    public async Task<IList<BriefIngredientDto>> GetIngredientsNotPaged()
    {
        var ingredients = await unit.Repository<Ingredient>()
            .GetAllAsync(null);

        var dtos = ingredients
            .Where(i => i.IsAdminApproved)
            .OrderBy(i => i.Name)
            .Select(i => i.ToBriefIngredientDto())
            .ToList();

        return dtos;
    }

    #endregion

    #region Suggest and CUD Operations on Ingredients
    public async Task SuggestIngredient(SuggestIngredientDto ingredient)
    {
        await unit.Repository<Ingredient>()
            .AddAsync(ingredient.ToIngredient());

        await unit.CompleteAsync();
    }

    public async Task<EditFormIngredientDto> CreateIngredientAsync(FormIngredientDto ingredientDto)
    {
        var ingredient = ingredientDto.ToIngredient();
        await unit.Repository<Ingredient>()
            .AddAsync(ingredient);

        await unit.CompleteAsync();

        return ingredient.ToEditFormIngredientDto();
    }

    public async Task UpdateIngredientAsync(EditFormIngredientDto ingredientDto, int id)
    {
        var ingredientToUpdate = await unit.Repository<Ingredient>()
            .GetByIdAsync(null, id);

        if (ingredientToUpdate == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Ingredient), id));
        }

        if (ingredientDto.Id != id)
        {
            throw new ValidationException(string.Format(UrlIdMismatch, nameof(Ingredient)));
        }

        ingredientToUpdate.UpdateFromDto(ingredientDto);

        unit.Repository<Ingredient>()
            .Update(ingredientToUpdate);

        await unit.CompleteAsync();

    }

    public async Task DeleteIngredientAsync(int id)
    {
        var ingredientToDelete = await unit.Repository<Ingredient>()
            .GetByIdAsync(null, id);

        if (ingredientToDelete == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Ingredient), id));
        }

        unit.Repository<Ingredient>().Delete(ingredientToDelete);

        await unit.CompleteAsync();
    }
    #endregion
}
