using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.DTOs;
public class DtoFactory(UserManager<AppUser> userManager) : IDtoFactory
{
    public IDto GetDto(object source, string dtoName)
    {
        switch (dtoName)
        {
            case nameof(SummaryRecipeDto):
                return CreateSummaryRecipeDto((Recipe)source);
        }

        return null;
    }

    private SummaryRecipeDto CreateSummaryRecipeDto(Recipe recipe)
    {
        return new SummaryRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            MainImageUrl =
                recipe.RecipeImages.FirstOrDefault()?.Url, //todo should set default image for recipe without image
            CookName = userManager.Users.FirstOrDefault(u => u.Id == recipe.Cook.UserId)?.DisplayName ?? "",
            Rating = recipe.RecipeRatings.Average(rr => rr.Value).ToString("F2"),
            Likes = userManager
                .Users
                .Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Categories = recipe.CategoryRecipes.Select(cr => cr.Category.Name).ToList()
        };

    }
}
