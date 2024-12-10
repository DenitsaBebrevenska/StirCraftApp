using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class CookMappingExtensions
{
    public static async Task<CookWithRankDto> ToCookWithRankDtoAsync(this Cook cook, UserManager<AppUser> userManager)
    {
        return new CookWithRankDto
        {
            Id = cook.Id,
            CookName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == cook.UserId))?.DisplayName ?? "",
            RankTitle = cook.CookingRank.Title,
            RankPoints = cook.RankingPoints
        };
    }

    public static async Task<SummaryCookDto> ToSummaryCookDtoAsync(this Cook cook, UserManager<AppUser> userManager)
    {
        return new SummaryCookDto
        {
            Id = cook.Id,
            DisplayName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == cook.UserId))?.DisplayName ?? "",
            AvatarUrl = (await userManager.Users.FirstAsync(u => u.Id == cook.UserId)).AvatarUrl,
            RecipesCount = cook.Recipes.Any() ? cook.Recipes.Count(r => r.IsAdminApproved) : 0,
            CookingRank = cook.CookingRank.Title,
            RankingPoints = cook.RankingPoints,
        };
    }

    public static async Task<DetailedCookDto> ToDetailedCookDtoAsync(this Cook cook, UserManager<AppUser> userManager)
    {
        return new DetailedCookDto
        {
            Id = cook.Id,
            DisplayName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == cook.UserId))?.DisplayName ?? "",
            AvatarUrl = (await userManager.Users.FirstAsync(u => u.Id == cook.UserId)).AvatarUrl,
            About = cook.About,
            RecipesCount = cook.Recipes.Any() ? cook.Recipes.Count(r => r.IsAdminApproved == true) : 0,
            CookingRank = cook.CookingRank.Title,
            RecipeLikes = cook.Recipes.Any() ? cook.Recipes.Sum(r => r.UserFavoriteRecipes.Count) : 0,
            RankingPoints = cook.RankingPoints,
        };
    }

    public static Cook ToCook(this CookAboutDto aboutDto, string userId)
    {
        return new Cook
        {
            UserId = userId,
            About = aboutDto.About,
            RankingPoints = 0,
            CookingRankId = 1
        };
    }
}
