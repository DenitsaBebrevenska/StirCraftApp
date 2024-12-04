using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.Image;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.JoinedTables;

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

    public static BriefCookRecipeDto ToBriefCookRecipeDto(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new BriefCookRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            Rating = recipe.RecipeRatings.Any() ? recipe.RecipeRatings.Average(rr => rr.Value) : 0,
            Likes = (uint)userManager.Users.Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id))
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
                recipe.RecipeImages.FirstOrDefault()?.Url,
            CookName = userManager.Users.FirstOrDefault(u => u.Id == recipe.Cook.UserId)?.DisplayName ?? "",
            Rating = recipe.RecipeRatings.Any() ? recipe.RecipeRatings.Average(rr => rr.Value).ToString("F2") : "0",
            Likes = userManager
                .Users
                .Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Categories = recipe.CategoryRecipes.Select(cr => cr.Category.Name).ToList()
        };

    }

    public static DetailedRecipeDto ToDetailedRecipeDto(this Recipe recipe, UserManager<AppUser> userManager, string? userId)
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
                CreatedOn = c.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
                UpdatedOn = c.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss"),
                Replies = c.Replies
                        .Select(r => new CommentReplyDto()
                        {
                            Id = r.Id,
                            Body = r.Body,
                            UserId = r.UserId,
                            UserDisplayName = userManager.Users.FirstOrDefault(u => u.Id == r.UserId)?.DisplayName ?? "",
                            CreatedOn = r.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
                            UpdatedOn = r.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss"),
                        })
                        .ToList()
            })
                .ToList(),
            IsLikedByCurrentUser = userId != null && recipe.UserFavoriteRecipes.Any(ufr => ufr.UserId == userId),
            CurrentUserRating = userId != null ? recipe.RecipeRatings.FirstOrDefault(rr => rr.UserId == userId)?.Value ?? 0 : 0
        };
    }

    public static RecipeOwnDto ToRecipeOwnDto(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new RecipeOwnDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            Rating = recipe.RecipeRatings.Any() ? recipe.RecipeRatings.Average(rr => rr.Value).ToString("F2") : "0",
            Likes = (uint)userManager
                .Users
                .Count(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            IsAdminApproved = recipe.IsAdminApproved
        };
    }

    public static DetailedRecipeAdminNotesDto ToDetailedRecipeAdminNotesDto(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new DetailedRecipeAdminNotesDto
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
            Ingredients = recipe.RecipeIngredients.Select(ri => new EditRecipeIngredientDto
            {
                Id = ri.Id,
                IngredientName = ri.Ingredient.Name,
                IngredientId = ri.Ingredient.Id,
                Quantity = ri.Quantity,
                MeasurementUnitId = ri.MeasurementUnitId,
                MeasurementAbbreviation = ri.MeasurementUnit?.Abbreviation
            }).ToList(),
            Images = recipe.RecipeImages.Select(ri => new RecipeImageDto
            {
                Id = ri.Id,
                Url = ri.Url
            }).ToList(),
            Categories = recipe.CategoryRecipes
                .Select(cr => new CategoryDto()
                {
                    Id = cr.CategoryId,
                    Name = cr.Category.Name
                })
                .ToList(),
            IsAdminApproved = recipe.IsAdminApproved,
            AdminNotes = recipe.AdminNotes
        };
    }

    public static Recipe ToRecipe(this FormRecipeDto createRecipeDto, int cookId)
    {
        return new Recipe
        {
            Name = createRecipeDto.Name,
            PreparationSteps = createRecipeDto.PreparationSteps,
            DifficultyLevel = Enum
                .TryParse(createRecipeDto.DifficultyLevel, true, out DifficultyLevel level) == false ?
                DifficultyLevel.Easy : level,
            CookId = cookId,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow,
            IsAdminApproved = false,
            AdminNotes = null,
            RecipeIngredients = createRecipeDto.RecipeIngredients.Select(i => new RecipeIngredient()
            {
                Id = i.Id,
                IngredientId = i.IngredientId,
                Quantity = i.Quantity,
                MeasurementUnitId = i.MeasurementUnitId
            }).ToList(),
            RecipeImages = createRecipeDto.RecipeImages.Select(i => new RecipeImage
            {
                Id = i.Id,
                Url = i.Url
            }).ToList(),
            CategoryRecipes = createRecipeDto.CategoryRecipes.Select(c => new CategoryRecipe
            {
                CategoryId = c
            }).ToList()
        };
    }

}

