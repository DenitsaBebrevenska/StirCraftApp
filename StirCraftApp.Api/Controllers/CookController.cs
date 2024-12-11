using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;
using static StirCraftApp.Domain.Constants.CachingValues;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Api.Controllers;

/// <summary>
/// Provides endpoints for managing cook-related operations, including profile management, becoming a cook, 
/// and handling cook-specific recipes.
/// </summary>
/// <remarks>
/// This controller requires authentication and provides role-specific endpoints for users with the "Cook" role.
/// Become cook method is available to users with the "User" role and allows them to apply to become a cook.
/// Routing is configured to use the "api/cook/" path by BaseApiController configurations.
/// </remarks>
public class CookController(IRecipeService recipeService, ICookService cookService, UserManager<AppUser> userManager) : BaseApiController
{
    #region Cook About Management

    /// <summary>
    /// Retrieves the about field of the authenticated cook.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with the cook's about data as a <see cref="CookAboutDto"/> object.
    /// </returns>
    /// <remarks>
    /// Only accessible by users with the "Cook" role.
    /// </remarks>
    [Authorize(Roles = CookRoleName)]
    [HttpGet("about")]
    [ProducesResponseType(typeof(CookAboutDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAbout()
    {
        var userId = User.GetId();

        var about = await cookService.GetCookAboutAsync(userId);
        return Ok(about);
    }

    /// <summary>
    /// Updates the about field of the authenticated cook.
    /// </summary>
    /// <param name="aboutDto">The updated about data for the cook.</param>
    /// <returns>
    /// Returns a 204 No Content status upon successful update.
    /// </returns>
    /// <remarks>
    /// Only accessible by users with the "Cook" role.
    /// </remarks>
    [Authorize(Roles = CookRoleName)]
    [HttpPut("about")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAbout(CookAboutDto aboutDto)
    {
        var userId = User.GetId();
        await cookService.UpdateAboutAsync(userId, aboutDto);
        return NoContent();
    }
    #endregion

    #region Become Cook
    /// <summary>
    /// Promotes an authenticated user to a cook role.
    /// </summary>
    /// <param name="aboutDto">Initial profile information for the cook.</param>
    /// <returns>
    /// Returns a 204 No Content status upon successful role update.
    /// </returns>
    /// <remarks>
    /// Only accessible by users with the "User" role.
    /// </remarks>
    [Authorize(Roles = UserRoleName)]
    [InvalidateCache(CooksCachePattern)]
    [HttpPost("become")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> BecomeCook(CookAboutDto aboutDto)
    {
        var userId = User.GetId();

        await cookService.BecomeCookAsync(aboutDto, userId);
        return NoContent();
    }
    #endregion

    #region Cook Own Recipes
    /// <summary>
    /// Retrieves a paginated list of recipes created by the authenticated cook.
    /// </summary>
    /// <param name="pagingParams">Pagination parameters for the request.</param>
    /// <returns>
    /// Returns a 200 OK status with a paginated list of recipes as <see cref="PaginatedResult{RecipeOwnDto}"/>.
    /// </returns>
    /// <remarks>
    /// Only accessible by users with the "Cook" role. Results are cached for performance.
    /// </remarks>
    [Authorize(Roles = CookRoleName)]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [HttpGet("recipes")]
    [ProducesResponseType(typeof(PaginatedResult<RecipeOwnDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCooksOwnRecipes([FromQuery] PagingParams pagingParams)
    {
        var cookId = await cookService.GetCookIdAsync(User.GetId()!);

        var spec = new RecipesByCurrentCookSpecification(pagingParams, cookId);
        var cookRecipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToRecipeOwnDtoAsync(userManager));
        return Ok(cookRecipes);
    }

    /// <summary>
    /// Retrieves detailed information about a specific recipe created by the authenticated cook.
    /// </summary>
    /// <param name="id">The ID of the recipe to retrieve.</param>
    /// <returns>
    /// Returns a 200 OK status with the recipe's details as a <see cref="DetailedRecipeAdminNotesDto"/> object.
    /// </returns>
    /// <remarks>
    /// Only accessible by users with the "Cook" role. Results are cached for performance.
    /// </remarks>
    [Authorize(Roles = CookRoleName)]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [HttpGet("recipes/{id}")]
    [ProducesResponseType(typeof(DetailedRecipeAdminNotesDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCookOwnRecipeById(int id)
    {
        var cookId = await cookService.GetCookIdAsync(User.GetId()!);

        var spec = new RecipeIncludeAllByCookSpecification(cookId);
        var recipe = await recipeService
            .GetRecipeByIdAsync(spec, id, async recipe => await recipe
                .ToDetailedRecipeAdminNotesDtoAsync(userManager));
        return Ok(recipe);
    }
    #endregion
}
