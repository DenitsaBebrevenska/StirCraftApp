using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;

public class RecipeService(IUnitOfWork unit, UserManager<AppUser> userManager) : IRecipeService
{
    //todo handle exceptions better
    public async Task<object> GetRecipeByIdAsync(ISpecification<Recipe>? spec, int id, string dtoName)
    {
        var recipeIsFound = await unit.Repository<Recipe>()
            .ExistsAsync(id);

        if (!recipeIsFound)
        {
            throw new Exception("Recipe not found");
        }

        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(spec, id);

        var model = ConvertToDto(recipe!, dtoName);

        return model;
    }

    public async Task<PaginatedResult> GetRecipesAsync(ISpecification<Recipe> spec, string dtoName)
    {
        var recipes = await unit.Repository<Recipe>()
            .GetAllAsync(spec);

        var recipeDtos = recipes.Select(r => ConvertToDto(r, dtoName)).ToList();

        var paginatedResult = new PaginatedResult(spec.Skip,
            spec.Take,
            recipeDtos.Count,
            recipeDtos);


        return paginatedResult;
    }

    public async Task<IEnumerable<object>> GetTopNRecipes(int count, string dtoName)
    {
        //todo probably different dto to use something for the home carousel
        var spec = new RecipeTopNSpecification(count);
        var recipes = await unit.Repository<Recipe>()
            .GetAllAsync(spec);

        var topRecipes = recipes.Select(r => ConvertToDto(r, dtoName)).ToList();

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

    public async Task AddRecipeToUsersFavoritesAsync(string userId, int recipeId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new ArgumentException("The user does not exist.");
        }

        var recipe = await unit.Repository<Recipe>().GetByIdAsync(null, recipeId);

        if (recipe == null)
        {
            throw new ArgumentException($"Recipe with id {recipeId} does not exist.");
        }

        if (user.FavoriteRecipes.Any(r => r.RecipeId == recipeId))
        {
            throw new ArgumentException($"The user already has that recipe in their favorites.");
        }

        user.FavoriteRecipes.Add(new UserFavoriteRecipe { Recipe = recipe, UserId = userId });


    }

    public async Task RemoveRecipeToUsersFavoritesAsync(string userId, int recipeId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new ArgumentException("The user does not exist.");
        }

        var recipe = await unit.Repository<Recipe>().GetByIdAsync(null, recipeId);

        if (recipe == null)
        {
            throw new ArgumentException($"Recipe with id {recipeId} does not exist.");
        }

        var userFavoriteRecipe = user.FavoriteRecipes.FirstOrDefault(r => r.RecipeId == recipeId);

        if (userFavoriteRecipe == null)
        {
            throw new ArgumentException($"Cannot remove recipe because it is not part of the user`s favorites.");
        }


        user.FavoriteRecipes.Remove(userFavoriteRecipe);

    }

    private object ConvertToDto(Recipe recipe, string dtoName)
    {
        return dtoName switch
        {
            nameof(SummaryRecipeDto) => recipe.ToSummaryRecipeDto(userManager),
            nameof(DetailedRecipeDto) => recipe.ToDetailedRecipeDto(userManager),
            nameof(CookRecipeSummaryDto) => recipe.ToCookRecipeSummaryDto(userManager),
            nameof(BriefRecipeDto) => recipe.ToBriefRecipeDto(userManager),
            nameof(BriefCookRecipeDto) => recipe.ToBriefCookRecipeDto(userManager),
            nameof(RecipeOwnDto) => recipe.ToRecipeOwnDto(userManager),
            nameof(DetailedRecipeAdminNotesDto) => recipe.ToDetailedRecipeAdminNotesDto(userManager),
            _ => throw new ArgumentException("Invalid DTO type")
        };
    }

}

