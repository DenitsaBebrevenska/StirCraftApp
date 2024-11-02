using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications;
using StirCraftApp.Infrastructure.Data.JoinedTables;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;

public class RecipeService(IUnitOfWork unit) : IRecipeService
{
    //todo handle exceptions better
    public async Task<DetailedRecipeDto> GetRecipeByIdAsync(int id)
    {
        //var recipe = await unit.Repository<Recipe>()
        //    .GetByIdAsync(id);

        //if (recipe is null)
        //{
        //    throw new Exception("Recipe not found");
        //}

        //var recipeImages = await unit.Repository<RecipeImage>()
        //    .GetAllAsync();
        //var recipeIngredients = await unit.Repository<RecipeIngredient>()
        //    .GetAllAsync();
        throw new NotImplementedException();
    }

    public async Task<PaginatedResult<SummaryRecipeDto>> GetRecipesAsync(RecipeSpecification specParams)
    {
        var recipes = await unit.Repository<Recipe>()
            .GetAllWithSpecAsync(specParams);
        var favoriteRecipes = await unit.Repository<UserFavoriteRecipe>()
            .GetAllAsync();
        var users = await unit.Repository<AppUser>()
            .GetAllAsync();
        var filtered = recipes.Select(r => new SummaryRecipeDto
        {
            Id = r.Id,
            Name = r.Name,
            DifficultyLevel = r.DifficultyLevel.ToString(),
            MainImageUrl = r.RecipeImages.FirstOrDefault()?.Url, //todo should set default image for recipe without image
            CookName = users.First(u => u.Id == r.Cook.UserId).DisplayName ?? "",
            Rating = r.RecipeRatings.Average(rr => rr.Value),
            Likes = favoriteRecipes.Count(fr => fr.RecipeId == r.Id)
        })
            .ToList();

        var paginatedResult = new PaginatedResult<SummaryRecipeDto>(specParams.Skip,
            specParams.Take,
            filtered.Count(),
            filtered);


        return paginatedResult;
    }
}

