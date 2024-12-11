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

/// <summary>
/// Implements the IIngredientService interface and uses the Unit of Work pattern for data access.
/// Provides functionality for managing ingredients in the system. This service supports retrieving ingredients 
/// by ID or in paginated lists, suggesting and creating new ingredients, as well as updating and deleting existing ones.
/// It includes methods for fetching ingredients with or without pagination, and allows the creation, update, and deletion 
/// of ingredient records. The service also handles ingredient suggestions submitted by users.
/// </summary>
public class IngredientService(IUnitOfWork unit) : IIngredientService
{
    #region Get Ingredients
    /// <summary>
    /// Retrieves an ingredient by its ID and converts it into a specified DTO.
    /// </summary>
    /// <typeparam name="T">The DTO type to return, which must derive from <see cref="BaseDto"/>.</typeparam>
    /// <param name="id">The ID of the ingredient to retrieve.</param>
    /// <param name="spec">An optional specification to filter the ingredient.</param>
    /// <param name="convertToDto">A function to convert the ingredient entity to the specified DTO.</param>
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

    /// <summary>
    /// Retrieves a paginated list of ingredients and converts each into a DTO.
    /// </summary>
    /// <typeparam name="T">The DTO type to return, which must derive from <see cref="BaseDto"/>.</typeparam>
    /// <param name="spec">An optional specification to filter the ingredients.</param>
    /// <param name="convertToDto">A function to convert each ingredient entity to the specified DTO.</param>
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

    /// <summary>
    /// Retrieves a list of ingredients without pagination, ordered by their name and filtered by approval status.
    /// </summary>
    /// <returns>A list of brief ingredient DTOs.</returns>
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
    /// <summary>
    /// Submits a suggested ingredient for approval.
    /// </summary>
    /// <param name="ingredient">The suggested ingredient DTO to be added.</param>
    public async Task SuggestIngredient(SuggestIngredientDto ingredient)
    {
        await unit.Repository<Ingredient>()
            .AddAsync(ingredient.ToIngredient());

        await unit.CompleteAsync();
    }

    /// <summary>
    /// Creates a new ingredient based on the provided form data and returns an edit DTO.
    /// </summary>
    /// <param name="ingredientDto">The form data for the ingredient.</param>
    /// <returns>An edit DTO for the created ingredient.</returns>
    public async Task<EditFormIngredientDto> CreateIngredientAsync(FormIngredientDto ingredientDto)
    {
        var ingredient = ingredientDto.ToIngredient();
        await unit.Repository<Ingredient>()
            .AddAsync(ingredient);

        await unit.CompleteAsync();

        return ingredient.ToEditFormIngredientDto();
    }

    /// <summary>
    /// Updates an existing ingredient based on the provided DTO.
    /// </summary>
    /// <param name="ingredientDto">The edit DTO containing updated ingredient data.</param>
    /// <param name="id">The ID of the ingredient to update.</param>
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

    /// <summary>
    /// Deletes an ingredient by its ID.
    /// </summary>
    /// <param name="id">The ID of the ingredient to delete.</param>
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
