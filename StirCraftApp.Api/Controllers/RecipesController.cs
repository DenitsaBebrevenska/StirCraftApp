﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService recipeService, ICookService cookService, ICommentService commentService, IReplyService replyService) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams specParams)
    {
        var spec = new RecipeFilterSortIncludeSpecification(specParams);
        var recipes = await recipeService.GetRecipesAsync(spec, nameof(SummaryRecipeDto));
        return Ok(recipes);
    }

    [AllowAnonymous]
    [HttpGet("top/{count}")]
    public async Task<IActionResult> GetTopNRecipes(int count)
    {
        var recipes = await recipeService.GetTopNRecipes(count, nameof(BriefRecipeDto));
        return Ok(recipes);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var currentUserId = User.GetId();
        var spec = new RecipeIncludeAllApprovedSpecification();
        var recipe = await recipeService.GetRecipeByIdAsync(spec, id, nameof(DetailedRecipeDto), currentUserId);
        return Ok(recipe);
    }

    [AllowAnonymous]
    [HttpGet("cook/{id}")]
    public async Task<IActionResult> GetRecipesByCookId(int id, [FromQuery] PagingParams pagingParams)
    {
        var spec = new RecipeByCookIdSpecification(pagingParams, id);
        var cookRecipes = await recipeService.GetRecipesAsync(spec, nameof(CookRecipeSummaryDto));
        return Ok(cookRecipes);
    }

    //implementing that through any service is not necessary, complicates it for no good reason
    [AllowAnonymous]
    [HttpGet("difficultyLevels")]
    public IActionResult GetDifficultyLevels()
    {
        var difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        return Ok(difficultyLevels);
    }

    [Authorize(Roles = CookRoleName)]
    [HttpPost]
    public async Task<IActionResult> CreateRecipe(FormRecipeDto createRecipeDto)
    {
        var cookId = await cookService.GetCookId(User.GetId());

        if (cookId == null)
        {
            return BadRequest("You need to become a cook to create a recipe");
        }

        await recipeService.CreateRecipeAsync(createRecipeDto, (int)cookId);

        //todo return created recipe ???
        return Ok();
    }

    [Authorize(Roles = CookRoleName)]
    [HttpPut("{id}/edit")]
    public async Task<IActionResult> UpdateRecipe(int id, EditFormRecipeDto updateRecipeDto)
    {
        if (updateRecipeDto.Id != id)
        {
            return BadRequest("Id in the body does not match the id in the route");
        }

        await recipeService.UpdateRecipeAsync(updateRecipeDto);
        return Ok();
    }

    [Authorize(Roles = CookRoleName)]
    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await recipeService.DeleteRecipeAsync(id);
        return Ok();
    }

    [Authorize(Roles = UserRoleName)]
    [HttpPost("{id}/toggle-favorite")]
    public async Task<IActionResult> ToggleFavorite(int id)
    {
        var userId = User.GetId();
        var dto = await recipeService.ToggleFavoriteAsync(userId, id);
        return Ok(dto);
    }

    [Authorize(Roles = UserRoleName)]
    [HttpGet("user-favorites")]
    public async Task<IActionResult> GetUserFavorites([FromQuery] PagingParams pagingParams)
    {
        var userId = User.GetId();
        var spec = new RecipeFavoritesSpecification(userId, pagingParams);
        var recipes = await recipeService.GetRecipesAsync(spec, nameof(BriefRecipeDto));
        return Ok(recipes);
    }

    [Authorize(Roles = UserRoleName)]
    [HttpPost("{id}/rate/{value}")]
    public async Task<IActionResult> RateRecipe(int id, int value)
    {
        var userId = User.GetId();
        var averageRating = await recipeService.RateRecipeAsync(userId, id, value);
        return Ok(averageRating);
    }

    [Authorize(Roles = UserAndCookRoleName)]

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> PostComment(int id, CommentFormDto commentFormDto)
    {
        var userId = User.GetId();

        await commentService.AddCommentAsync(userId, id, commentFormDto);
        return Ok(); //todo return created comment
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [HttpPut("{id}/comments/{commentId}")]
    public async Task<IActionResult> EditComment(int commentId, EditFormCommentDto commentEditFormDto)
    {
        var userId = User.GetId();

        if (commentId != commentEditFormDto.Id)
        {
            return BadRequest("Id in the body does not match the id in the route");
        }

        await commentService.EditCommentAsync(userId, commentEditFormDto);

        return Ok();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [HttpDelete("{id}/comments/{commentId}")]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var userId = User.GetId();

        await commentService.DeleteCommentAsync(userId, commentId);
        return Ok();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [HttpPost("{id}/comments/{commentId}/replies")]
    public async Task<IActionResult> PostReply(ReplyFormDto replyFormDto, int commentId)
    {
        var userId = User.GetId();

        await replyService.AddReplyAsync(userId, commentId, replyFormDto);
        return Ok(); //todo return created reply
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [HttpPut("{id}/comments/{commentId}/replies/{replyId}")]
    public async Task<IActionResult> EditReply(int replyId, ReplyEditFormDto replyEditForm)
    {
        var userId = User.GetId();

        if (replyId != replyEditForm.Id)
        {
            return BadRequest("Id in the body does not match the id in the route");
        }

        await replyService.EditReplyAsync(userId, replyEditForm);

        return Ok();
    }

    [Authorize(Roles = UserAndCookRoleName)]
    [HttpDelete("{id}/comments/{commentId}/replies/{replyId}")]
    public async Task<IActionResult> DeleteReply(int replyId)
    {
        var userId = User.GetId();

        await replyService.DeleteReplyAsync(userId, replyId);
        return Ok();
    }

}
