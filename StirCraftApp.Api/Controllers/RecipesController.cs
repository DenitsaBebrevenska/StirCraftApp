using Microsoft.AspNetCore.Authorization;
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

/// <summary>
/// Manages CRUD operations for recipes, user actions such as rating and liking, and nested resources like comments and replies.
/// </summary>
/// <remarks>
/// This controller offers a wide range of endpoints for both anonymous and authorized users.
/// Key features include recipe CRUD, user interactions (favorites and ratings), and comment/reply management.
/// Includes caching and cache invalidation for optimized performance.
/// Routing is configured to use the "api/recipes/" path and default behavior is set to authorize all actions by BaseApiController configurations 
/// unless overriden.
/// </remarks>
public class RecipesController(IRecipeService recipeService,
    ICookService cookService,
    ICommentService commentService,
    IReplyService replyService,
    UserManager<AppUser> userManager)
    : BaseApiController
{
    #region Recipe CRUD

    /// <summary>
    /// Retrieves a paginated list of recipes with optional filters and sorting.
    /// </summary>
    /// <param name="specParams">Query parameters for filtering, sorting, and pagination.</param>
    /// <returns>A 200 OK response with a paginated list of recipes as <see cref="PaginatedResult{SummaryRecipeDto}"/>.</returns>
    /// <remarks>
    /// Accessible anonymously and uses caching for improved performance.
    /// </remarks>
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

    /// <summary>
    /// Retrieves the top N recipes based on likes.
    /// </summary>
    /// <param name="count">The number of top recipes to retrieve.</param>
    /// <returns>A 200 OK response with a list of recipes as <see cref="IEnumerable{BriefRecipeDto}"/>.</returns>
    /// <remarks>
    /// Accessible anonymously and uses caching for performance optimization.
    /// </remarks>
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

    /// <summary>
    /// Retrieves detailed information about a specific recipe by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the recipe.</param>
    /// <returns>A 200 OK response with the recipe details as <see cref="DetailedRecipeDto"/>.</returns>
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

    /// <summary>
    /// Retrieves recipes created by a specific cook, with pagination support.
    /// </summary>
    /// <param name="id">The unique identifier of the cook.</param>
    /// <param name="pagingParams">Pagination parameters.</param>
    /// <returns>A 200 OK response with a paginated list of recipes as <see cref="PaginatedResult{CookRecipeSummaryDto}"/>.</returns>
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

    /// <summary>
    /// Retrieves the list of possible difficulty levels for recipes.
    /// </summary>
    /// <returns>A 200 OK response with an array of difficulty level names.</returns>
    /// <remarks>
    /// Useful for front-end dropdowns or validation.
    /// </remarks>
    [AllowAnonymous]
    [HttpGet("difficultyLevels")]
    [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
    public IActionResult GetDifficultyLevels()
    {
        var difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        return Ok(difficultyLevels);
    }


    /// <summary>
    /// Allows a cook to create a new recipe.
    /// </summary>
    /// <param name="createRecipeDto">Data transfer object containing recipe details.</param>
    /// <returns>A 201 Created response with the newly created recipe's details.</returns>
    /// <remarks>
    /// Restricted to authenticated cooks and invalidates relevant cache entries upon success.
    /// </remarks>
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

    /// <summary>
    /// Updates an existing recipe.
    /// </summary>
    /// <param name="id">The ID of the recipe to update.</param>
    /// <param name="updateRecipeDto">Data transfer object containing updated recipe details.</param>
    /// <returns>A 204 No Content response if the update succeeds.</returns>
    /// <remarks>
    /// Restricted to authenticated cooks and invalidates relevant cache entries upon success.
    /// </remarks>
    [Authorize(Roles = CookRoleName)]
    [InvalidateCache(CookOwnRecipesCachePattern, RecipeAdminCachePattern)]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateRecipe(int id, EditFormRecipeDto updateRecipeDto)
    {

        await recipeService.UpdateRecipeAsync(id, updateRecipeDto);
        return NoContent();
    }


    /// <summary>
    /// Deletes a recipe by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the recipe to delete.</param>
    /// <returns>A 204 No Content response if the deletion succeeds.</returns>
    /// <remarks>
    /// Restricted to authenticated cooks and invalidates relevant cache entries upon success.
    /// </remarks>
    [Authorize(Roles = CookRoleName)]
    [InvalidateCache(CookOwnRecipesCachePattern, RecipesCachePattern)]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await recipeService.DeleteRecipeAsync(id);
        return NoContent();
    }

    #endregion

    #region User Recipe Actions

    /// <summary>
    /// Toggles the favorite status of a recipe for the current user.
    /// </summary>
    /// <param name="id">The ID of the recipe to toggle.</param>
    /// <returns>A 200 OK response with the updated favorite status.</returns>
    /// <remarks>
    /// Restricted to authenticated users and invalidates relevant cache entries.
    /// </remarks>
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

    /// <summary>
    /// Retrieves a paginated list of the user's favorite recipes.
    /// </summary>
    /// <param name="pagingParams">Pagination parameters.</param>
    /// <returns>A 200 OK response with the user's favorite recipes as <see cref="PaginatedResult{BriefRecipeDto}"/>.</returns>
    /// <remarks>
    /// Restricted to authenticated users and uses caching for performance.
    /// </remarks>
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

    /// <summary>
    /// Rates a recipe and returns the updated average rating.
    /// </summary>
    /// <param name="id">The ID of the recipe to rate.</param>
    /// <param name="value">The rating value (e.g., 1 to 5).</param>
    /// <returns>A 200 OK response with the updated average rating.</returns>
    /// <remarks>
    /// Restricted to authenticated users and invalidates relevant cache entries.
    /// </remarks>
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

    #endregion

    #region Comments CRUD

    /// <summary>
    /// Posts a comment on a recipe.
    /// </summary>
    /// <param name="id">The ID of the recipe to comment on.</param>
    /// <param name="commentFormDto">Data transfer object containing the comment's content.</param>
    /// <returns>A 204 No Content response upon successful creation.</returns>
    /// <remarks>
    /// Restricted to authenticated users or cooks and invalidates relevant cache entries.
    /// </remarks>
    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPost("{id}/comments")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostComment(int id, CommentFormDto commentFormDto)
    {
        var userId = User.GetId();

        await commentService
             .AddCommentAsync(id, commentFormDto, userId!);
        return NoContent();
    }

    /// <summary>
    /// Edits a comment by its ID.
    /// </summary>
    /// <param name="id">The ID of the recipe associated with this comment.</param>
    /// <param name="commentId">The ID of the comment to edit.</param>
    /// <param name="commentEditFormDto">Data transfer object containing updated comment details.</param>
    /// <returns>A 204 No Content response upon successful update.</returns>
    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPut("{id}/comments/{commentId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditComment(int id, int commentId, EditFormCommentDto commentEditFormDto)
    {
        var userId = User.GetId();

        await commentService
            .EditCommentAsync(id, commentId, commentEditFormDto, userId!);
        return NoContent();
    }

    /// <summary>
    /// Deletes a comment by its ID.
    /// </summary>
    /// <param name="id">The ID of the recipe associated with this comment.</param>
    /// <param name="commentId">The ID of the comment to delete.</param>
    /// <returns>A 204 No Content response upon successful deletion.</returns>
    /// <remarks>
    /// Invalidates relevant cache entries upon success.
    /// </remarks>
    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpDelete("{id}/comments/{commentId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteComment(int id, int commentId)
    {
        var userId = User.GetId();

        await commentService
            .DeleteCommentAsync(id, commentId, userId!);
        return NoContent();
    }

    #endregion

    #region Reply CRUD

    /// <summary>
    /// Posts a reply to a specific comment.
    /// </summary>
    /// <param name="id">The ID of the recipe associated with this comment and reply.</param>
    /// <param name="replyFormDto">Data transfer object containing reply details.</param>
    /// <param name="commentId">The ID of the comment to reply to.</param>
    /// <returns>A 204 No Content response upon successful creation.</returns>
    /// <remarks>
    /// Restricted to authenticated users or cooks and invalidates relevant cache entries.
    /// </remarks>
    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPost("{id}/comments/{commentId}/replies")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostReply(int id, ReplyFormDto replyFormDto, int commentId)
    {
        var userId = User.GetId();

        await replyService
            .AddReplyAsync(id, commentId, replyFormDto, userId!);
        return NoContent();
    }

    /// <summary>
    /// Edits a reply by its ID.
    /// </summary>
    /// <param name="id">The id of the recipe associated with the comment and reply.</param>
    /// <param name="commentId">The id of the comment to which the reply belongs to.</param>
    /// <param name="replyId">The ID of the reply to edit.</param>
    /// <param name="replyEditForm">Data transfer object containing updated reply details.</param>
    /// <returns>A 204 No Content response upon successful update.</returns>
    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpPut("{id}/comments/{commentId}/replies/{replyId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditReply(int id, int commentId, int replyId, ReplyEditFormDto replyEditForm)
    {
        var userId = User.GetId();

        await replyService
            .EditReplyAsync(id, commentId, replyId, replyEditForm, userId!);

        return NoContent();
    }

    /// <summary>
    /// Deletes a reply by its ID.
    /// </summary>
    /// <param name="id">The id of the recipe associated with the comment and reply.</param>
    /// <param name="commentId">The id of the comment to which the reply belongs to.</param>
    /// <param name="replyId">The ID of the reply to delete.</param>
    /// <returns>A 204 No Content response upon successful deletion.</returns>
    /// <remarks>
    /// Invalidates relevant cache entries upon success.
    /// </remarks>
    [Authorize(Roles = UserAndCookRoleName)]
    [InvalidateCache(RecipesCachePattern)]
    [HttpDelete("{id}/comments/{commentId}/replies/{replyId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteReply(int id, int commentId, int replyId)
    {
        var userId = User.GetId();

        await replyService
            .DeleteReplyAsync(id, commentId, replyId, userId!);
        return NoContent();
    }

    #endregion
}
