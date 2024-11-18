﻿using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Mappings;
public static class CookMappingExtensions
{
    public static SummaryCookDto ToSummaryCookDto(this Cook cook, UserManager<AppUser> userManager)
    {
        return new SummaryCookDto
        {
            Id = cook.Id,
            DisplayName = userManager.Users.First(u => u.Id == cook.UserId).DisplayName ?? "",
            AvatarUrl = userManager.Users.First(u => u.Id == cook.UserId).AvatarUrl,
            RecipesCount = cook.Recipes.Any() ? (uint)cook.Recipes.Count : 0,
            CookingRank = cook.CookingRank.Title,
            RankingPoints = cook.RankingPoints,
        };
    }

    public static DetailedCookDto ToDetailedCookDto(this Cook cook, UserManager<AppUser> userManager)
    {
        return new DetailedCookDto
        {
            Id = cook.Id,
            DisplayName = userManager.Users.First(u => u.Id == cook.UserId).DisplayName ?? "",
            AvatarUrl = userManager.Users.First(u => u.Id == cook.UserId).AvatarUrl,
            About = cook.About,
            RecipesCount = cook.Recipes.Any() ? (uint)cook.Recipes.Count : 0,
            CookingRank = cook.CookingRank.Title,
            RecipeLikes = cook.Recipes.Any() ? (uint)cook.Recipes.Sum(r => r.UserFavoriteRecipes.Count) : 0,
            RankingPoints = cook.RankingPoints,
        };
    }
}