using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.DTOs.RecipeDtos.Comment;
using StirCraftApp.Application.DTOs.RecipeDtos.Image;
using StirCraftApp.Application.DTOs.RecipeDtos.Ingredient;
using StirCraftApp.Application.DTOs.RecipeDtos.Reply;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Mappings;
public static class RecipeMappingExtensions
{
    public static BriefRecipeDto ToBriefRecipeDto(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new BriefRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            CookName = userManager.Users.FirstOrDefault(u => u.Id == recipe.Cook.UserId)?.DisplayName ?? "",
        };
    }

    public static CookRecipeSummaryDto ToCookRecipeSummaryDto(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new CookRecipeSummaryDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            Rating = recipe.RecipeRatings.Any() ? recipe.RecipeRatings.Average(rr => rr.Value) : 0,
            Likes = (uint)userManager.Users.Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Categories = recipe.CategoryRecipes.Select(cr => cr.Category.Name).ToList()
        };
    }

    public static SummaryRecipeDto ToSummaryRecipeDto(this Recipe recipe, UserManager<AppUser> userManager)
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

    public static DetailedRecipeDto ToDetailedRecipeDto(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new DetailedRecipeDto
        {
            Id = recipe!.Id,
            Name = recipe.Name,
            PreparationSteps = recipe.PreparationSteps,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            CookId = recipe.Cook.Id,
            CookName = userManager.Users.FirstOrDefault(u => u.Id == recipe.Cook.UserId)?.DisplayName ?? "",
            CreatedOn = recipe.CreatedOn.ToString("dd/MM/yyyy"),
            UpdatedOn = recipe.UpdatedOn.ToString("dd/MM/yyyy"),
            Rating = recipe.RecipeRatings.Any() ? recipe.RecipeRatings.Average(rr => rr.Value) : 0,
            Likes = userManager.Users.Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientDto
            {
                Id = ri.Ingredient.Id,
                Name = ri.Ingredient.Name,
                Quantity = ri.Quantity,
                MeasurementUnitName = ri.MeasurementUnit?.Abbreviation
            }).ToList(),
            Images = recipe.RecipeImages.Select(ri => new RecipeImageDto
            {
                Id = ri.Id,
                Url = ri.Url
            }).ToList(),
            Categories = recipe.CategoryRecipes
                .Select(cr => cr.Category.Name)
                .ToList(),
            Comments = recipe.Comments.Select(c => new RecipeCommentDto
            {
                Id = c.Id,
                Body = c.Body,
                Title = c.Title,
                UserId = c.UserId,
                UserDisplayName = userManager.Users.FirstOrDefault(u => u.Id == c.UserId)?.DisplayName ?? "",
                Replies = c.Replies
                        .Select(r => new CommentReplyDto()
                        {
                            Id = r.Id,
                            Body = r.Body,
                            UserId = r.UserId,
                            UserDisplayName = userManager.Users.FirstOrDefault(u => u.Id == r.UserId)?.DisplayName ?? ""
                        })
                        .ToList()
            })
                .ToList()
        };
    }
}
