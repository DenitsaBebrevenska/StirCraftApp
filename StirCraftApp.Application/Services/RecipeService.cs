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
    public async Task<IEnumerable<QuickViewRecipeDto>> GetRecipesAsync(RecipeSpecification specParams)
    {
        var recipes = await unit.Repository<Recipe>()
            .GetAllWithSpecAsync(specParams);
        var favoriteRecipes = await unit.Repository<UserFavoriteRecipe>()
            .GetAllAsync();
        var users = await unit.Repository<AppUser>()
            .GetAllAsync();
        var filtered = recipes.Select(r => new QuickViewRecipeDto
        {
            Id = r.Id,
            Name = r.Name,
            DifficultyLevel = r.DifficultyLevel.ToString(),
            MainImageUrl = r.RecipeImages.FirstOrDefault()?.Url,
            CookName = users.First(u => u.Id == r.Cook.UserId).DisplayName ?? "",
            Rating = r.RecipeRatings.Average(rr => rr.Value),
            Likes = favoriteRecipes.Count(fr => fr.RecipeId == r.Id)
        });

        return filtered;
    }

}

