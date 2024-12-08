using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Application.Services;

public class RecipeService(IUnitOfWork unit, UserManager<AppUser> userManager) : IRecipeService
{
    //todo handle exceptions better
    public async Task<T> GetRecipeByIdAsync<T>(ISpecification<Recipe>? spec, int id, Func<Recipe, Task<T>> convertToDto) where T : BaseDto
    {
        var recipeIsFound = await unit.Repository<Recipe>()
            .ExistsAsync(id);

        if (!recipeIsFound)
        {
            throw new Exception("Recipe not found");
        }

        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(spec, id);

        var dto = await convertToDto(recipe!);

        return dto;
    }

    public async Task<PaginatedResult<T>> GetRecipesAsync<T>(ISpecification<Recipe> spec, Func<Recipe, Task<T>> convertToDto) where T : BaseDto
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

    public async Task UpdateRecipeAsync(EditFormRecipeDto updateRecipeDto)
    {
        //todo clear up this monstrous method
        var spec = new RecipeIncludeAllSpecification();
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(spec, updateRecipeDto.Id);

        if (recipe == null)
        {
            throw new ArgumentException("Recipe not found");
        }

        recipe.Name = updateRecipeDto.Name;
        recipe.PreparationSteps = updateRecipeDto.PreparationSteps;
        recipe.DifficultyLevel = Enum
            .TryParse(updateRecipeDto.DifficultyLevel, true, out DifficultyLevel level) == false
            ? DifficultyLevel.Easy
            : level;
        recipe.UpdatedOn = DateTime.UtcNow;

        recipe.CategoryRecipes.Clear();

        foreach (var categoryId in updateRecipeDto.CategoryRecipes)
        {
            recipe.CategoryRecipes.Add(new CategoryRecipe
            {
                CategoryId = categoryId,
                RecipeId = recipe.Id
            });
        }

        foreach (var ri in updateRecipeDto.RecipeIngredients)
        {
            if (recipe.RecipeIngredients.Any(i => i.Id == ri.Id))
            {
                var ingredient = recipe.RecipeIngredients.First(i => i.Id == ri.Id);
                ingredient.IngredientId = ri.IngredientId;
                ingredient.Quantity = ri.Quantity;
                ingredient.MeasurementUnitId = ri.MeasurementUnitId;
                continue;
            }

            recipe.RecipeIngredients.Add(new RecipeIngredient
            {
                IngredientId = ri.IngredientId,
                Quantity = ri.Quantity,
                MeasurementUnitId = ri.MeasurementUnitId
            });
        }

        foreach (var image in updateRecipeDto.RecipeImages)
        {
            if (recipe.RecipeImages.Any(i => i.Id == image.Id))
            {
                var imageFound = recipe.RecipeImages.First(i => i.Id == image.Id);
                imageFound.Url = image.Url;
                continue;
            }

            recipe.RecipeImages.Add(new RecipeImage
            {
                Url = image.Url
            });
        }

        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();
    }

    public async Task DeleteRecipeAsync(int id)
    {
        var recipeToDelete = await unit.Repository<Recipe>()
            .GetByIdAsync(null, id);

        if (recipeToDelete == null)
        {
            throw new Exception($"Recipe with id {id} not found");
        }

        unit.Repository<Recipe>().Delete(recipeToDelete);

        await unit.CompleteAsync();
    }

    public async Task<FavoriteRecipeToggleDto> ToggleFavoriteAsync(string userId, int recipeId)
    {
        var spec = new RecipeWithFavoritesApprovedSpecification();
        var recipes = await unit.Repository<Recipe>()
            .GetAllAsync(spec);
        var recipeFound = recipes.FirstOrDefault(r => r.UserFavoriteRecipes.Any(ufr => ufr.UserId == userId
            && ufr.RecipeId == recipeId));

        if (recipeFound != null)
        {
            recipes.First(r => r.Id == recipeId)
                .UserFavoriteRecipes
                .Remove(recipeFound.UserFavoriteRecipes.First(ufr => ufr.UserId == userId));
            await unit.CompleteAsync();

            return new FavoriteRecipeToggleDto()
            {
                IsFavorite = false,
                TotalLikes = (uint)recipeFound.UserFavoriteRecipes.Count
            };
        }

        recipes.First(r => r.Id == recipeId)
            .UserFavoriteRecipes
            .Add(new UserFavoriteRecipe
            {
                UserId = userId,
                RecipeId = recipeId
            });
        await unit.CompleteAsync();

        return new FavoriteRecipeToggleDto()
        {
            IsFavorite = true,
            TotalLikes = (uint)recipes.First(r => r.Id == recipeId).UserFavoriteRecipes.Count()
        };
    }

    public async Task<double> RateRecipeAsync(string userId, int recipeId, int rating)
    {
        var recipeExists = await unit.Repository<Recipe>().ExistsAsync(recipeId);

        if (recipeExists == false)
        {
            throw new Exception("Recipe not found");
        }

        if (rating < RecipeRatingMinValue || rating > RecipeRatingMaxValue)
        {
            throw new Exception($"Invalid rating! The rating must be in the range between {RecipeRatingMinValue} and {RecipeRatingMaxValue} inclusive");
        }


        var recipeRatings = await unit.Repository<RecipeRating>()
            .GetAllAsync(null);

        var ratingFound = recipeRatings.FirstOrDefault(rr => rr.UserId == userId && rr.RecipeId == recipeId);

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

        return recipeRatings.Any(rr => rr.RecipeId == recipeId)
            ? recipeRatings.Where(rr => rr.RecipeId == recipeId).Average(rr => rr.Value)
            : 0;
    }

    public async Task UpdateAdminNotesAsync(int id, AdminNotesDto adminNotesDto)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(null, id);
        if (recipe == null)
        {
            throw new Exception("Recipe not found");
        }

        recipe.AdminNotes = adminNotesDto.AdminNotes;
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();
    }

    public async Task ApproveRecipeAsync(int id)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(null, id);
        if (recipe == null)
        {
            throw new Exception("Recipe not found");
        }

        recipe.IsAdminApproved = true;
        unit.Repository<Recipe>().Update(recipe);
        await unit.CompleteAsync();
    }

}

