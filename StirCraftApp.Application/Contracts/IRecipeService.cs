using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface IRecipeService
{
    Task<T> GetRecipeByIdAsync<T>(ISpecification<Recipe>? spec, int id, Func<Recipe, Task<T>> convertToDto) where T : BaseDto;

    Task<PaginatedResult<T>> GetRecipesAsync<T>(ISpecification<Recipe> spec, Func<Recipe, Task<T>> convertToDto)
        where T : BaseDto;
    Task<IEnumerable<T>> GetTopNRecipes<T>(int count, Func<Recipe, Task<T>> convertToDto) where T : BaseDto;
    Task CreateRecipeAsync(FormRecipeDto createRecipeDto, int cookId);
    Task UpdateRecipeAsync(EditFormRecipeDto updateRecipeDto);
    Task DeleteRecipeAsync(int id);
    Task<FavoriteRecipeToggleDto> ToggleFavoriteAsync(string userId, int recipeId);

    Task<double> RateRecipeAsync(string userId, int recipeId, int rating);

    Task UpdateAdminNotesAsync(int id, AdminNotesDto adminNotesDto);

    Task ApproveRecipeAsync(int id);
}

