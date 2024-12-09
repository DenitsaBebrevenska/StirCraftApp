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
[Route("api/[controller]")]
[ApiController]

public class CookController(IRecipeService recipeService, ICookService cookService, UserManager<AppUser> userManager) : BaseApiController
{
    [Authorize(Roles = CookRoleName)]
    [HttpGet("about")]
    [ProducesResponseType(typeof(CookAboutDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAbout()
    {
        var userId = User.GetId();

        var about = await cookService.GetCookAboutAsync(userId);
        return Ok(about);
    }

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

    [Authorize(Roles = CookRoleName)]
    [HttpPut("about")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAbout(CookAboutDto aboutDto)
    {
        var userId = User.GetId();
        await cookService.UpdateAboutAsync(userId, aboutDto);
        return NoContent();
    }

    [Authorize(Roles = CookRoleName)]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [HttpGet("recipes")]
    [ProducesResponseType(typeof(PaginatedResult<RecipeOwnDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCooksOwnRecipes([FromQuery] PagingParams pagingParams)
    {
        var cookId = await cookService.GetCookIdAsync(User.GetId());

        var spec = new RecipesByCurrentCookSpecification(pagingParams, cookId);
        var cookRecipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToRecipeOwnDtoAsync(userManager));
        return Ok(cookRecipes);
    }

    [Authorize(Roles = CookRoleName)]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    [HttpGet("recipes/{id}")]
    [ProducesResponseType(typeof(DetailedRecipeAdminNotesDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCookOwnRecipeById(int id)
    {
        var cookId = await cookService.GetCookIdAsync(User.GetId());

        var spec = new RecipeIncludeAllByCookSpecification(cookId);
        var recipe = await recipeService
            .GetRecipeByIdAsync(spec, id, async recipe => await recipe
                .ToDetailedRecipeAdminNotesDtoAsync(userManager));
        return Ok(recipe);
    }

}
