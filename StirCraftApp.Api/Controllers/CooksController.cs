using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using static StirCraftApp.Domain.Constants.CachingValues;

namespace StirCraftApp.Api.Controllers;

/// <summary>
/// Provides endpoints for retrieving cook information, including paginated lists of cooks, 
/// detailed profiles by ID, and top-ranked cooks.
/// </summary>
/// <remarks>
/// This controller is publicly accessible without authentication.
/// Routing is configured to use the "api/cooks/" path by BaseApiController configurations.
/// </remarks>
[AllowAnonymous]
public class CooksController(ICooksService cooksService, UserManager<AppUser> userManager) : ControllerBase
{
    /// <summary>
    /// Retrieves a paginated list of cooks based on the provided specifications.
    /// </summary>
    /// <param name="specParams">Parameters for filtering, sorting, and paginating the list of cooks.</param>
    /// <returns>
    /// Returns a 200 OK status with a paginated result of cooks as <see cref="PaginatedResult{SummaryCookDto}"/>.
    /// </returns>
    /// <remarks>
    /// Results are cached for moderate duration to improve performance.
    /// </remarks>
    [HttpGet]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [ProducesResponseType(typeof(PaginatedResult<SummaryCookDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCooks([FromQuery] CookSpecParams specParams)
    {
        var spec = new CookSortIncludeSpecification(specParams);
        var cooks = await cooksService
            .GetCooksAsync(spec, cook => cook
                .ToSummaryCookDtoAsync(userManager));
        return Ok(cooks);
    }

    /// <summary>
    /// Retrieves detailed information about a specific cook by their ID.
    /// </summary>
    /// <param name="id">The ID of the cook to retrieve.</param>
    /// <returns>
    /// Returns a 200 OK status with the cook's detailed information as a <see cref="DetailedCookDto"/>.
    /// </returns>
    /// <remarks>
    /// Results are cached for moderate duration to improve performance.
    /// </remarks>
    [HttpGet("{id}")]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [ProducesResponseType(typeof(DetailedCookDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCookById(int id)
    {
        var cook = await cooksService
            .GetCookByIdAsync(id, cook => cook
                .ToDetailedCookDtoAsync(userManager));
        return Ok(cook);
    }

    /// <summary>
    /// Retrieves the top cooks with the highest ranks, limited by the specified count.
    /// </summary>
    /// <param name="count">The number of top-ranked cooks to retrieve.</param>
    /// <returns>
    /// Returns a 200 OK status with a result of top-ranked cooks as <see cref="PaginatedResult{CookWithRankDto}"/>.
    /// </returns>
    /// <remarks>
    /// Results are cached for a short duration to improve performance.
    /// </remarks>
    [HttpGet("top/{count}")]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [ProducesResponseType(typeof(PaginatedResult<CookWithRankDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTopTenCooksWithRanks(int count)
    {
        var spec = new CookTopRankSpecification(count);
        var cooks = await cooksService
            .GetCooksAsync(spec, cook => cook
                .ToCookWithRankDtoAsync(userManager));
        return Ok(cooks);
    }
}
