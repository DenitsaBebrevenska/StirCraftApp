using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Specifications.IngredientSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using static StirCraftApp.Domain.Constants.CachingValues;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Api.Controllers;

/// <summary>
/// Provides endpoints for managing ingredients, including retrieval of paginated or non-paginated lists
/// and functionality for cooks to suggest new ingredients.
/// </summary>
/// <remarks>
/// Contains endpoints accessible by anonymous users and authenticated cooks.
/// Routing is configured to use the "api/ingredients/" path by BaseApiController configurations.
/// </remarks>
public class IngredientsController(IIngredientService ingredientService) : BaseApiController
{
    /// <summary>
    /// Retrieves a paginated list of approved ingredients based on specified filtering and sorting parameters.
    /// </summary>
    /// <param name="specParams">Parameters for filtering, sorting, and paginating the list of ingredients.</param>
    /// <returns>
    /// Returns a 200 OK status with a paginated result of ingredients as <see cref="PaginatedResult{BriefIngredientDto}"/>.
    /// </returns>
    /// <remarks>
    /// This endpoint is accessible anonymously and leverages moderate caching to enhance performance.
    /// </remarks>
    [HttpGet]
    [AllowAnonymous]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [ProducesResponseType(typeof(PaginatedResult<BriefIngredientDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientSpecParams specParams)
    {
        var spec = new IngredientFilterAdminApprovedSpecification(specParams);
        var ingredients = await ingredientService
            .GetIngredientsAsync(spec, ingredient => ingredient
                .ToBriefIngredientDto());
        return Ok(ingredients);
    }

    /// <summary>
    /// Retrieves a non-paginated list of all approved ingredients.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with a list of ingredients as <see cref="IList{BriefIngredientDto}"/>.
    /// </returns>
    /// <remarks>
    /// This endpoint is accessible anonymously and leverages moderate caching for performance optimization.
    /// </remarks>
    [HttpGet("all")]
    [AllowAnonymous]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [ProducesResponseType(typeof(IList<BriefIngredientDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIngredientsAllNonPaged()
    {
        var nonPagedIngredients = await ingredientService.GetIngredientsNotPaged();
        return Ok(nonPagedIngredients);
    }

    /// <summary>
    /// Allows authenticated cooks to suggest a new ingredient for approval by an admin.
    /// </summary>
    /// <param name="dto">The details of the suggested ingredient encapsulated in a <see cref="SuggestIngredientDto"/>.</param>
    /// <returns>
    /// Returns a 204 No Content status upon successful submission of the suggestion.
    /// </returns>
    /// <remarks>
    /// Invalidates cached data related to ingredients in the admin panel to ensure fresh data is available post-suggestion.
    /// This endpoint is restricted to users with the "Cook" role.
    /// </remarks>
    [HttpPost("suggest")]
    [Authorize(Roles = CookRoleName)]
    [InvalidateCache(IngredientsAdminCachePattern)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SuggestIngredient(SuggestIngredientDto dto)
    {
        await ingredientService.SuggestIngredient(dto);
        return NoContent();
    }
}
