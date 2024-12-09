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

public class RecipeService(IUnitOfWork unit, ICookingRankService cookingRankService) : IRecipeService
{
    public async Task<T> GetRecipeByIdAsync<T>(ISpecification<Recipe>? spec, int id, Func<Recipe, Task<T>> convertToDto)
        where T : BaseDto
    {
        var recipe = await EnsureRecipeExistsAsync(id, spec);
        var dto = await convertToDto(recipe);

        return dto;
    }

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


    public async Task CreateRecipeAsync(FormRecipeDto createRecipeDto, int cookId)
    {
        var recipe = createRecipeDto.ToRecipe(cookId);

        await unit.Repository<Recipe>().AddAsync(recipe);

        await unit.CompleteAsync();
    }

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

    public async Task DeleteRecipeAsync(int id)
    {
        var recipe = await EnsureRecipeExistsAsync(id);
        unit.Repository<Recipe>().Delete(recipe);

        await unit.CompleteAsync();

        await cookingRankService.CalculatePoints(recipe.CookId, DeletingARecipe);
    }

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
                TotalLikes = (uint)recipeFound.UserFavoriteRecipes.Count
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
            TotalLikes = (uint)recipes.First(r => r.Id == recipeId).UserFavoriteRecipes.Count()
        };
    }

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

    public async Task UpdateAdminNotesAsync(int id, AdminNotesDto adminNotesDto)
    {
        var recipe = await EnsureRecipeExistsAsync(id);

        recipe.AdminNotes = adminNotesDto.AdminNotes;
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();
    }

    public async Task ApproveRecipeAsync(int id)
    {
        var recipe = await EnsureRecipeExistsAsync(id);

        recipe.IsAdminApproved = true;
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();

        await cookingRankService.CalculatePoints(recipe.CookId, UploadingARecipe);
    }

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

    private void RemoveUnusedImages(Recipe recipe, IEnumerable<RecipeImageDto> formImages)
    {
        var removedImages = recipe.RecipeImages
            .Where(ri => formImages.All(riDto => riDto.Id != ri.Id))
            .ToList();

        foreach (var ri in removedImages)
        {
            unit.Repository<RecipeImage>().Delete(ri);
        }
    }

}
