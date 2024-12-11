using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;
using static StirCraftApp.Domain.Constants.RankingConstants;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Implements the ICookingRankService interface and uses the Unit of Work pattern for data access, and user manager for user related actions.
/// Service class that provides functionality for managing recipes in the application. This class includes CRUD operations 
/// for recipes, user interactions such as toggling favorites and ratings, as well as admin-related actions for approving and 
/// updating recipes. It also handles the necessary validation and transformation of recipes to various data transfer objects (DTOs).
/// </summary>
public class RecipeService(IUnitOfWork unit, ICookingRankService cookingRankService, UserManager<AppUser> userManager) : IRecipeService
{
    #region CRUD
    /// <summary>
    /// Retrieves a recipe by its ID, applying an optional specification and converting it to a DTO.
    /// </summary>
    /// <typeparam name="T">The type of DTO to convert the recipe to.</typeparam>
    /// <param name="spec">An optional specification to filter the recipe.</param>
    /// <param name="id">The ID of the recipe to retrieve.</param>
    /// <param name="convertToDto">A function to convert the recipe to the DTO.</param>
    /// <returns>The converted DTO of the recipe.</returns>
    public async Task<T> GetRecipeByIdAsync<T>(ISpecification<Recipe>? spec, int id, Func<Recipe, Task<T>> convertToDto)
        where T : BaseDto
    {
        var recipe = await EnsureRecipeExistsAsync(id, spec);
        var dto = await convertToDto(recipe);

        return dto;
    }

    /// <summary>
    /// Retrieves a list of recipes based on the provided specification and converts them into DTOs.
    /// </summary>
    /// <typeparam name="T">The type of DTO to convert the recipes to.</typeparam>
    /// <param name="spec">The specification used to filter the recipes.</param>
    /// <param name="convertToDto">A function to convert each recipe to a DTO.</param>
    /// <returns>A paginated result containing the list of recipe DTOs.</returns>
    public async Task<PaginatedResult<T>> GetRecipesAsync<T>(ISpecification<Recipe> spec,
        Func<Recipe, Task<T>> convertToDto) where T : BaseDto
    {
        var recipes = await unit.Repository<Recipe>()
            .GetAllAsync(spec);

        var count = await unit.Repository<Recipe>()
            .CountAsync(spec);

        var recipeDtos = new List<T>();

        foreach (var recipe in recipes)
        {
            recipeDtos.Add(await convertToDto(recipe));
        }

        var paginatedResult = new PaginatedResult<T>(spec.Skip,
            spec.Take,
            count,
            recipeDtos);


        return paginatedResult;
    }

    /// <summary>
    /// Retrieves the top N recipes based on a specification and converts them into DTOs.
    /// </summary>
    /// <typeparam name="T">The type of DTO to convert the recipes to.</typeparam>
    /// <param name="count">The number of top recipes to retrieve.</param>
    /// <param name="convertToDto">A function to convert each recipe to a DTO.</param>
    /// <returns>A collection of the top N recipe DTOs.</returns>
    public async Task<IEnumerable<T>> GetTopNRecipes<T>(int count, Func<Recipe, Task<T>> convertToDto) where T : BaseDto
    {

        var spec = new RecipeTopNSpecification(count);
        var recipes = await unit.Repository<Recipe>()
            .GetAllAsync(spec);

        var topRecipes = new List<T>();
        foreach (var recipe in recipes)
        {
            topRecipes.Add(await convertToDto(recipe));
        }

        return topRecipes;
    }

    /// <summary>
    /// Creates a new recipe based on the provided data, associates it with the specified cook, and returns the detailed DTO.
    /// </summary>
    /// <param name="createRecipeDto">The DTO containing the recipe creation data.</param>
    /// <param name="cookId">The ID of the cook creating the recipe.</param>
    /// <returns>A task that represents the asynchronous operation, with the detailed recipe DTO as the result.</returns>
    public async Task<DetailedRecipeDto> CreateRecipeAsync(FormRecipeDto createRecipeDto, int cookId)
    {
        var recipe = createRecipeDto.ToRecipe(cookId);

        await unit.Repository<Recipe>().AddAsync(recipe);

        await unit.CompleteAsync();

        var userId = await unit.Repository<Cook>()
            .GetByIdAsync(null, cookId)
            .ContinueWith(t => t.Result!.UserId);

        var recipeFound = await unit.Repository<Recipe>()
            .GetByIdAsync(new RecipeIncludeAllSpecification(), recipe.Id);
        return await recipeFound!.ToDetailedRecipeDtoAsync(userManager, userId);
    }

    /// <summary>
    /// Updates an existing recipe based on the provided ID and DTO. Validates the data and ensures only relevant changes are made.
    /// Validates the ID of the recipe and the ID in the DTO to prevent mismatch errors. If an error occurs, a validation exception is thrown.
    /// </summary>
    /// <param name="id">The ID of the recipe to update.</param>
    /// <param name="updateRecipeDto">The DTO containing the updated recipe data.</param>
    public async Task UpdateRecipeAsync(int id, EditFormRecipeDto updateRecipeDto)
    {
        if (id != updateRecipeDto.Id)
        {
            throw new ValidationException(string.Format(UrlIdMismatch, nameof(Recipe)));
        }

        var spec = new RecipeIncludeAllSpecification();
        var recipe = await EnsureRecipeExistsAsync(id, spec);

        recipe.UpdateBaseFromDto(updateRecipeDto);
        recipe.UpdateRecipeCategories(updateRecipeDto.CategoryRecipes);
        RemoveUnusedIngredients(recipe, updateRecipeDto.RecipeIngredients);
        recipe.UpdateRecipeIngredients(updateRecipeDto.RecipeIngredients);
        RemoveUnusedImages(recipe, updateRecipeDto.RecipeImages);
        recipe.UpdateRecipeImages(updateRecipeDto.RecipeImages);
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();
    }

    /// <summary>
    /// Deletes a recipe based on the provided ID and recalculates the cooking rank points for the cook who authored it.
    /// </summary>
    /// <param name="id">The ID of the recipe to delete.</param>
    public async Task DeleteRecipeAsync(int id)
    {
        var recipe = await EnsureRecipeExistsAsync(id);
        unit.Repository<Recipe>().Delete(recipe);

        await unit.CompleteAsync();

        await cookingRankService.CalculatePoints(recipe.CookId, DeletingARecipe);
    }

    #endregion

    #region User Related Actions

    /// <summary>
    /// Toggles the favorite status of a recipe for the specified user and updates the total likes count.
    /// </summary>
    /// <param name="userId">The ID of the user performing the action.</param>
    /// <param name="recipeId">The ID of the recipe to toggle the favorite status for.</param>
    /// <returns>A DTO indicating whether the recipe is now a favorite and the total likes count which is useful to the front end.</returns>
    public async Task<FavoriteRecipeToggleDto> ToggleFavoriteAsync(string userId, int recipeId)
    {
        var spec = new RecipeWithFavoritesApprovedSpecification();
        var recipes = await unit.Repository<Recipe>()
            .GetAllAsync(spec);
        var recipeFound = recipes.FirstOrDefault(r => r.UserFavoriteRecipes
            .Any(ufr => ufr.UserId == userId
            && ufr.RecipeId == recipeId));

        if (recipeFound != null)
        {
            recipes.First(r => r.Id == recipeId)
                .UserFavoriteRecipes
                .Remove(recipeFound.UserFavoriteRecipes.First(ufr => ufr.UserId == userId));
            await unit.CompleteAsync();

            await cookingRankService.CalculatePoints(recipeFound.CookId, UnlikingARecipe);

            return new FavoriteRecipeToggleDto()
            {
                IsFavorite = false,
                TotalLikes = recipeFound.UserFavoriteRecipes.Count
            };
        }

        var recipe = recipes.First(r => r.Id == recipeId);

        recipe.UserFavoriteRecipes
            .Add(new UserFavoriteRecipe
            {
                UserId = userId,
                RecipeId = recipeId
            });

        await unit.CompleteAsync();

        await cookingRankService.CalculatePoints(recipe.CookId, LikingARecipe);

        return new FavoriteRecipeToggleDto
        {
            IsFavorite = true,
            TotalLikes = recipes.First(r => r.Id == recipeId).UserFavoriteRecipes.Count()
        };
    }

    /// <summary>
    /// Rates a recipe by the specified user and calculates the average rating for the recipe.
    /// Validates the rating value to ensure it falls within the acceptable range. If the rating is invalid, a validation exception is thrown.
    /// </summary>
    /// <param name="userId">The ID of the user providing the rating.</param>
    /// <param name="recipeId">The ID of the recipe being rated.</param>
    /// <param name="rating">The rating value provided by the user.</param>
    /// <returns>The average rating of the recipe.</returns>
    public async Task<double> RateRecipeAsync(string userId, int recipeId, int rating)
    {

        if (rating < RecipeRatingMinValue || rating > RecipeRatingMaxValue)
        {
            throw new ValidationException(string.Format(RangeError, nameof(rating), RecipeRatingMinValue,
                RecipeRatingMaxValue));
        }

        var recipe = await EnsureRecipeExistsAsync(recipeId);

        var ratingFound = recipe.RecipeRatings.FirstOrDefault(rr => rr.UserId == userId);

        if (ratingFound != null)
        {
            ratingFound.Value = rating;
            await unit.CompleteAsync();
        }
        else
        {
            await unit.Repository<RecipeRating>().AddAsync(new RecipeRating
            {
                UserId = userId,
                RecipeId = recipeId,
                Value = rating
            });

            await unit.CompleteAsync();
        }

        return recipe.RecipeRatings.Any(rr => rr.RecipeId == recipeId)
            ? recipe.RecipeRatings.Where(rr => rr.RecipeId == recipeId)
                .Average(rr => rr.Value)
            : 0;
    }

    #endregion

    #region Admin Related Actions
    /// <summary>
    /// Updates the admin notes for a recipe.
    /// </summary>
    /// <param name="id">The ID of the recipe.</param>
    /// <param name="adminNotesDto">The DTO containing the admin notes.</param>
    public async Task UpdateAdminNotesAsync(int id, AdminNotesDto adminNotesDto)
    {
        var recipe = await EnsureRecipeExistsAsync(id);

        recipe.AdminNotes = adminNotesDto.AdminNotes;
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();
    }

    /// <summary>
    /// Approves a recipe for publishing and calculates rank points for the cook.
    /// </summary>
    /// <param name="id">The ID of the recipe.</param>
    public async Task ApproveRecipeAsync(int id)
    {
        var recipe = await EnsureRecipeExistsAsync(id);

        recipe.IsAdminApproved = true;
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();

        await cookingRankService.CalculatePoints(recipe.CookId, UploadingARecipe);
    }

    #endregion

    #region Helper Methods for recipe update
    /// <summary>
    /// A helper method that ensures that a recipe with the specified ID exists and returns it.
    /// Validates the existence of the recipe and throws a NotFoundException if the recipe does not exist.
    /// </summary>
    /// <param name="id">The ID of the recipe </param>
    /// <param name="spec">The specification used to filter the recipe.</param>
    /// <returns>The recipe by the specified ID.</returns>
    private async Task<Recipe> EnsureRecipeExistsAsync(int id, ISpecification<Recipe>? spec = null)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(spec, id);

        if (recipe == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Recipe), id));
        }

        return recipe;
    }

    /// <summary>
    /// A helper method that removes any ingredients that are not included in the updated recipe.
    /// </summary>
    /// <param name="recipe">The recipe that is being updated.</param>
    /// <param name="formIngredients">The DTO transferring the data to be updated.</param>
    private void RemoveUnusedIngredients(Recipe recipe, IEnumerable<FormRecipeIngredientDto> formIngredients)
    {
        var removedIngredients = recipe.RecipeIngredients
            .Where(ri => formIngredients.All(riDto => riDto.Id != ri.Id))
            .ToList();

        foreach (var ri in removedIngredients)
        {
            unit.Repository<RecipeIngredient>().Delete(ri);
        }
    }

    /// <summary>
    /// A helper method that removes any images that are not included in the updated recipe.
    /// </summary>
    /// <param name="recipe">The recipe that is being updated.</param>
    /// <param name="formImages">The DTO transferring the data to be updated.</param>
    private void RemoveUnusedImages(Recipe recipe, IEnumerable<RecipeImageDto> formImages)
    {
        var removedImages = recipe.RecipeImages
            .Where(ri => formImages.All(riDto => riDto.Url != ri.Url))
            .ToList();

        foreach (var ri in removedImages)
        {
            unit.Repository<RecipeImage>().Delete(ri);
        }
    }
    #endregion
}
