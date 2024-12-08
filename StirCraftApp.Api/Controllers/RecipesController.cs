﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;
using static StirCraftApp.Domain.Constants.CachingValues;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService recipeService, ICookService cookService, ICommentService commentService, IReplyService replyService, UserManager<AppUser> userManager) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [ProducesResponseType(typeof(PaginatedResult<SummaryRecipeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams specParams)
    {
        var spec = new RecipeFilterSortIncludeSpecification(specParams);
        var recipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToSummaryRecipeDtoAsync(userManager));
        return Ok(recipes);
    }

    [AllowAnonymous]
    [HttpGet("top/{count}")]
    [ProducesResponseType(typeof(IEnumerable<BriefRecipeDto>), StatusCodes.Status200OK)]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    public async Task<IActionResult> GetTopNRecipes(int count)
    {
        var recipes = await recipeService
            .GetTopNRecipes(count, async recipe => await recipe
                .ToBriefRecipeDtoAsync(userManager));
        return Ok(recipes);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DetailedRecipeDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var currentUserId = User.GetId();
        var spec = new RecipeIncludeAllApprovedSpecification();
        var recipe = await recipeService
            .GetRecipeByIdAsync(spec, id, async recipe => await recipe
                .ToDetailedRecipeDtoAsync(userManager, currentUserId));
        return Ok(recipe);
    }

    [AllowAnonymous]
    [HttpGet("cook/{id}")]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [ProducesResponseType(typeof(PaginatedResult<CookRecipeSummaryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRecipesByCookId(int id, [FromQuery] PagingParams pagingParams)
    {
        var spec = new RecipeByCookIdSpecification(pagingParams, id);
        var cookRecipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToCookRecipeSummaryDtoAsync(userManager));
        return Ok(cookRecipes);
    }

    [AllowAnonymous]
    [HttpGet("difficultyLevels")]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public IActionResult GetDifficultyLevels()
    {
        var difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        return Ok(difficultyLevels);
    }

    [Authorize(Roles = CookRoleName)]
    [InvalidateCache(CookOwnRecipesCachePattern, RecipeAdminCachePattern)]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRecipe(FormRecipeDto createRecipeDto)
    {
        var cookId = await cookService.GetCookIdAsync(User.GetId()!);

        var createdRecipe = await recipeService.CreateRecipeAsync(createRecipeDto, cookId);

        return CreatedAtAction(nameof(GetRecipe), new { id = createdRecipe.Id }, createdRecipe);
    }

    [Authorize(Roles = CookRoleName)]
    [InvalidateCache(CookOwnRecipesCachePattern, RecipeAdminCachePattern)]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateRecipe(int id, EditFormRecipeDto updateRecipeDto)
    {

        await recipeService.UpdateRecipeAsync(id, updateRecipeDto);
        return NoContent();
    }

    [Authorize(Roles = CookRoleName)]
    [InvalidateCache(CookOwnRecipesCachePattern, RecipesCachePattern)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await recipeService.DeleteRecipeAsync(id);
        return NoContent();
    }

    [Authorize(Roles = UserRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPost("{id}/toggle-favorite")]
    [ProducesResponseType(typeof(FavoriteRecipeToggleDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ToggleFavorite(int id)
    {
        var userId = User.GetId();
        var dto = await recipeService.ToggleFavoriteAsync(userId!, id);
        return Ok(dto);
    }

    [Authorize(Roles = UserRoleName)]
    [HttpGet("user-favorites")]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [InvalidateCache(RecipesCachePattern)]
    [ProducesResponseType(typeof(PaginatedResult<BriefRecipeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserFavorites([FromQuery] PagingParams pagingParams)
    {
        var userId = User.GetId();
        var spec = new RecipeFavoritesSpecification(userId!, pagingParams);
        var recipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToBriefRecipeDtoAsync(userManager));
        return Ok(recipes);
    }

    [Authorize(Roles = UserRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPost("{id}/rate/{value}")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    public async Task<IActionResult> RateRecipe(int id, int value)
    {
        var userId = User.GetId();
        var averageRating = await recipeService
            .RateRecipeAsync(userId!, id, value);
        return Ok(averageRating);
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPost("{id}/comments")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostComment(int id, CommentFormDto commentFormDto)
    {
        var userId = User.GetId();

        await commentService
             .AddCommentAsync(userId!, id, commentFormDto);
        return NoContent();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPut("{id}/comments/{commentId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditComment(int commentId, EditFormCommentDto commentEditFormDto)
    {
        var userId = User.GetId();

        await commentService
            .EditCommentAsync(userId!, commentId, commentEditFormDto);
        return NoContent();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpDelete("{id}/comments/{commentId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var userId = User.GetId();

        await commentService
            .DeleteCommentAsync(userId!, commentId);
        return NoContent();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPost("{id}/comments/{commentId}/replies")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostReply(ReplyFormDto replyFormDto, int commentId)
    {
        var userId = User.GetId();

        await replyService
            .AddReplyAsync(userId!, commentId, replyFormDto);
        return NoContent();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPut("{id}/comments/{commentId}/replies/{replyId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditReply(int replyId, ReplyEditFormDto replyEditForm)
    {
        var userId = User.GetId();

        await replyService
            .EditReplyAsync(userId!, replyId, replyEditForm);

        return NoContent();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpDelete("{id}/comments/{commentId}/replies/{replyId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteReply(int replyId)
    {
        var userId = User.GetId();

        await replyService
            .DeleteReplyAsync(userId!, replyId);
        return NoContent();
    }

}
