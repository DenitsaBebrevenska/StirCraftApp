using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.JoinedTables;

namespace StirCraftApp.Application.Mappings;
public static class RecipeMappingExtensions
{

    public static async Task<BriefRecipeDto> ToBriefRecipeDtoAsync(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new BriefRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            CookName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
        };
    }

    public static async Task<BriefCookRecipeDto> ToBriefCookRecipeDtoAsync(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new BriefCookRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id))
        };
    }

    public static async Task<CookRecipeSummaryDto> ToCookRecipeSummaryDtoAsync(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new CookRecipeSummaryDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Categories = recipe.CategoryRecipes.Select(cr => cr.Category.Name).ToList()
        };
    }

    public static async Task<SummaryRecipeDto> ToSummaryRecipeDtoAsync(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new SummaryRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            MainImageUrl =
                recipe.RecipeImages.FirstOrDefault()?.Url,
            CookName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Categories = recipe.CategoryRecipes.Select(cr => cr.Category.Name).ToList()
        };

    }

    public static async Task<DetailedRecipeDto> ToDetailedRecipeDtoAsync(this Recipe recipe, UserManager<AppUser> userManager, string? userId)
    {
        var dto = new DetailedRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            PreparationSteps = recipe.PreparationSteps,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            CookId = recipe.Cook.Id,
            CookName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
            CreatedOn = recipe.CreatedOn.ToString("dd/MM/yyyy"),
            UpdatedOn = recipe.UpdatedOn.ToString("dd/MM/yyyy"),
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
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
            IsLikedByCurrentUser = userId != null && recipe.UserFavoriteRecipes.Any(ufr => ufr.UserId == userId),
            CurrentUserRating = userId != null ? recipe.RecipeRatings.FirstOrDefault(rr => rr.UserId == userId)?.Value ?? 0 : 0
        };

        var comments = new List<RecipeCommentDto>();

        foreach (var comment in recipe.Comments)
        {
            var commentDto = new RecipeCommentDto
            {
                Id = comment.Id,
                Body = comment.Body,
                Title = comment.Title,
                UserId = comment.UserId,
                UserDisplayName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == comment.UserId))?.DisplayName ?? "",
                CreatedOn = comment.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
                UpdatedOn = comment.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss"),
                Replies = new List<CommentReplyDto>()
            };

            foreach (var reply in comment.Replies)
            {
                commentDto.Replies.Add(new CommentReplyDto
                {
                    Id = reply.Id,
                    Body = reply.Body,
                    UserId = reply.UserId,
                    UserDisplayName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == reply.UserId))?.DisplayName ?? "",
                    CreatedOn = reply.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
                    UpdatedOn = reply.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss")
                });
            }
        }

        dto.Comments = comments;

        return dto;
    }

    public static async Task<RecipeOwnDto> ToRecipeOwnDtoAsync(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new RecipeOwnDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            MainImageUrl = recipe.RecipeImages.FirstOrDefault()?.Url,
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            IsAdminApproved = recipe.IsAdminApproved
        };
    }

    public static async Task<DetailedRecipeAdminNotesDto> ToDetailedRecipeAdminNotesDtoAsync(this Recipe recipe, UserManager<AppUser> userManager)
    {
        return new DetailedRecipeAdminNotesDto
        {
            Id = recipe!.Id,
            Name = recipe.Name,
            PreparationSteps = recipe.PreparationSteps,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            CookId = recipe.Cook.Id,
            CookName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
            CreatedOn = recipe.CreatedOn.ToString("dd/MM/yyyy"),
            UpdatedOn = recipe.UpdatedOn.ToString("dd/MM/yyyy"),
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
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

