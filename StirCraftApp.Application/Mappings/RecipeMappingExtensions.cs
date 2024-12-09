using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
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
            CookName =
                (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
        };
    }

    public static async Task<CookRecipeSummaryDto> ToCookRecipeSummaryDtoAsync(this Recipe recipe,
        UserManager<AppUser> userManager)
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

    public static async Task<SummaryRecipeDto> ToSummaryRecipeDtoAsync(this Recipe recipe,
        UserManager<AppUser> userManager)
    {
        return new SummaryRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            MainImageUrl =
                recipe.RecipeImages.FirstOrDefault()?.Url,
            CookName =
                (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Categories = recipe.CategoryRecipes.Select(cr => cr.Category.Name).ToList()
        };

    }

    public static async Task<DetailedRecipeDto> ToDetailedRecipeDtoAsync(this Recipe recipe,
        UserManager<AppUser> userManager, string? userId)
    {
        var dto = new DetailedRecipeDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            PreparationSteps = recipe.PreparationSteps,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            CookId = recipe.Cook.Id,
            CookName =
                (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
            CreatedOn = recipe.CreatedOn.ToString("dd/MM/yyyy"),
            UpdatedOn = recipe.UpdatedOn.ToString("dd/MM/yyyy"),
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Ingredients = recipe.RecipeIngredients.Select(ri => ri.ToRecipeIngredientDto()).ToList(),
            Images = recipe.RecipeImages.Select(ri => ri.ToRecipeImageDto()).ToList(),
            Categories = recipe.CategoryRecipes
                .Select(cr => cr.Category.Name)
                .ToList(),
            IsLikedByCurrentUser = userId != null && recipe.UserFavoriteRecipes.Any(ufr => ufr.UserId == userId),
            CurrentUserRating = userId != null
                ? recipe.RecipeRatings.FirstOrDefault(rr => rr.UserId == userId)?.Value ?? 0
                : 0
        };

        var comments = new List<RecipeCommentDto>();

        foreach (var comment in recipe.Comments)
        {
            var commentDto = await comment.ToRecipeCommentDtoAsync(userManager);

            foreach (var reply in comment.Replies)
            {
                var replyDto = await reply.ToCommentReplyDtoAsync(userManager);
                commentDto.Replies.Add(replyDto);
            }

            comments.Add(commentDto);
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


    public static async Task<DetailedRecipeAdminNotesDto> ToDetailedRecipeAdminNotesDtoAsync(this Recipe recipe,
        UserManager<AppUser> userManager)
    {
        return new DetailedRecipeAdminNotesDto
        {
            Id = recipe.Id,
            Name = recipe.Name,
            PreparationSteps = recipe.PreparationSteps,
            DifficultyLevel = recipe.DifficultyLevel.ToString(),
            CookId = recipe.Cook.Id,
            CookName =
                (await userManager.Users.FirstOrDefaultAsync(u => u.Id == recipe.Cook.UserId))?.DisplayName ?? "",
            CreatedOn = recipe.CreatedOn.ToString("dd/MM/yyyy"),
            UpdatedOn = recipe.UpdatedOn.ToString("dd/MM/yyyy"),
            Rating = recipe.RecipeRatings.Any() ? Math.Round(recipe.RecipeRatings.Average(rr => rr.Value), 2) : 0,
            Likes = await userManager.Users.CountAsync(u => u.FavoriteRecipes.Any(ufr => ufr.RecipeId == recipe.Id)),
            Ingredients = recipe.RecipeIngredients.Select(ri => ri.ToEditRecipeIngredientDto()).ToList(),
            Images = recipe.RecipeImages.Select(ri => ri.ToRecipeImageDto()).ToList(),
            Categories = recipe.CategoryRecipes
                .Select(cr => cr.Category.ToDto())
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
                .TryParse(createRecipeDto.DifficultyLevel, true, out DifficultyLevel level) == false
                ? DifficultyLevel.Easy
                : level,
            CookId = cookId,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow,
            IsAdminApproved = false,
            AdminNotes = null,
            RecipeIngredients = createRecipeDto.RecipeIngredients.Select(i => i.ToRecipeIngredient()).ToList(),
            RecipeImages = createRecipeDto.RecipeImages.Select(i => i.ToRecipeImage()).ToList(),
            CategoryRecipes = createRecipeDto.CategoryRecipes.Select(c => new CategoryRecipe
            {
                CategoryId = c
            }).ToList()
        };
    }

    public static void UpdateBaseFromDto(this Recipe recipe, EditFormRecipeDto updateRecipeDto)
    {
        recipe.Name = updateRecipeDto.Name;
        recipe.PreparationSteps = updateRecipeDto.PreparationSteps;
        recipe.DifficultyLevel = Enum
            .TryParse(updateRecipeDto.DifficultyLevel, true, out DifficultyLevel level) == false
            ? DifficultyLevel.Easy
            : level;
        recipe.UpdatedOn = DateTime.UtcNow;
        recipe.IsAdminApproved = false;
    }

    public static void UpdateRecipeCategories(this Recipe recipe, IEnumerable<int> categoryIds)
    {
        recipe.CategoryRecipes.Clear();
        foreach (var categoryId in categoryIds)
        {
            recipe.CategoryRecipes.Add(new CategoryRecipe
            {
                CategoryId = categoryId,
                RecipeId = recipe.Id
            });
        }

    }

    public static void UpdateRecipeIngredients(this Recipe recipe, IEnumerable<FormRecipeIngredientDto> ingredientDtos)
    {

        foreach (var ri in ingredientDtos)
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
                MeasurementUnitId = ri.MeasurementUnitId,
                RecipeId = recipe.Id
            });
        }

    }

    public static void UpdateRecipeImages(this Recipe recipe, IEnumerable<RecipeImageDto> imageDtos)
    {
        recipe.RecipeImages.Clear();
        foreach (var image in imageDtos)
        {
            recipe.RecipeImages.Add(new RecipeImage
            {
                Url = image.Url
            });
        }
    }
}
