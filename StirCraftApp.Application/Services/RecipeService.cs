using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;

public class RecipeService(IUnitOfWork unit, UserManager<AppUser> userManager) : IRecipeService
{
    //todo handle exceptions better
    public async Task<object> GetRecipeByIdAsync(int id, string dtoName)
    {
        var recipeIsFound = await unit.Repository<Recipe>()
            .ExistsAsync(id);

        if (!recipeIsFound)
        {
            throw new Exception("Recipe not found");
        }

        var spec = new RecipeIncludeAllSpecification();
        var recipe = await unit.Repository<Recipe>()
            .GetEntityWithSpecAsync(spec, id);

        var model = ConvertToDto(recipe!, dtoName);

        return model;
    }

    public async Task<PaginatedResult> GetRecipesAsync(BaseSpecification<Recipe> spec, string dtoName)
    {
        var recipes = await unit.Repository<Recipe>()
            .GetAllWithSpecAsync(spec);

        var recipeDtos = recipes.Select(r => ConvertToDto(r, dtoName)).ToList();

        var paginatedResult = new PaginatedResult(spec.Skip,
            spec.Take,
            recipeDtos.Count,
            recipeDtos);


        return paginatedResult;
    }

    public async Task<IEnumerable<object>> GetTopThreeRecipes(string dtoName)
    {
        //todo probably different dto to use something for the home carousel
        var spec = new RecipeTopThreeSpecification();
        var recipes = await unit.Repository<Recipe>()
            .GetAllWithSpecAsync(spec);

        var topThree = recipes.Select(r => ConvertToDto(r, dtoName)).ToList();

        return topThree;
    }

    public async Task CreateRecipeAsync(FormRecipeDto createRecipeDto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRecipeAsync(FormRecipeDto updateRecipeDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteRecipeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddRecipeToUsersFavorites(string userId, int recipeId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new ArgumentException("The user does not exist.");
        }

        var recipe = await unit.Repository<Recipe>().GetByIdAsync(recipeId);

        if (recipe == null)
        {
            throw new ArgumentException($"Recipe with id {recipeId} does not exist.");
        }

        user.FavoriteRecipes.Add(new UserFavoriteRecipe { Recipe = recipe, UserId = userId });

    }

    private object ConvertToDto(Recipe recipe, string dtoName)
    {
        return dtoName switch
        {
            nameof(SummaryRecipeDto) => recipe.ToSummaryRecipeDto(userManager),
            nameof(DetailedRecipeDto) => recipe.ToDetailedRecipeDto(userManager),
            nameof(CookRecipeSummaryDto) => recipe.ToCookRecipeSummaryDto(userManager),
            nameof(BriefRecipeDto) => recipe.ToBriefRecipeDto(userManager),
            _ => throw new ArgumentException("Invalid DTO type")
        };
    }

}

