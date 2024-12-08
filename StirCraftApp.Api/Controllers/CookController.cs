using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = CookRoleName)]
public class CookController(IRecipeService recipeService, ICookService cookService, UserManager<AppUser> userManager) : BaseApiController
{

    [HttpGet("about")]
    public async Task<IActionResult> GetAbout()
    {
        var userId = User.GetId();

        var about = await cookService.GetCookAboutAsync(userId);
        return Ok(about);
    }

    [Authorize(Roles = UserRoleName)]
    [HttpPost("become")]
    public async Task<IActionResult> BecomeCook(CookAboutDto aboutDto)
    {
        var userId = User.GetId();

        await cookService.CreateCookAsync(aboutDto, userId);
        return Ok();
    }

    [HttpPut("about")]
    public async Task<IActionResult> UpdateAbout(CookAboutDto aboutDto)
    {
        var userId = User.GetId();
        await cookService.UpdateAboutAsync(userId, aboutDto);
        return Ok();
    }


    [HttpGet("recipes")]
    public async Task<IActionResult> GetCooksOwnRecipes([FromQuery] PagingParams pagingParams)
    {
        var cookId = await cookService.GetCookIdAsync(User.GetId());

        var spec = new RecipesByCurrentCookSpecification(pagingParams, cookId);
        var cookRecipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToRecipeOwnDtoAsync(userManager));
        return Ok(cookRecipes);
    }

    [HttpGet("recipes/{id}")]
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
