using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CookController(IRecipeService recipeService, ICookService cookService) : ControllerBase
{

    [HttpPost("become")]
    public async Task<IActionResult> BecomeCook(BecomeCookDto dto)
    {
        var userId = User.GetId();

        await cookService.CreateCookAsync(dto, userId);
        return Ok();
    }


    [HttpGet("recipes")]
    public async Task<IActionResult> GetCooksOwnRecipes([FromQuery] PagingParams pagingParams)
    {
        var cookId = await cookService.GetCookId(User.GetId());

        if (cookId == null)
        {
            return NotFound();
        }

        var spec = new RecipesByCurrentCookSpecification(pagingParams, (int)cookId);
        var cookRecipes = await recipeService.GetRecipesAsync(spec, nameof(RecipeOwnDto));
        return Ok(cookRecipes);
    }

    [HttpGet("recipes/{id}")]
    public async Task<IActionResult> GetCookOwnRecipeById(int id)
    {
        var cookId = await cookService.GetCookId(User.GetId());

        if (cookId == null)
        {
            return NotFound();
        }

        if (await cookService.CookIsTheRecipeOwner((int)cookId, id) == false)
        {
            return Unauthorized();
        }

        var spec = new RecipeIncludeAllSpecification();

        var recipe = await recipeService.GetRecipeByIdAsync(spec, id, nameof(DetailedRecipeAdminNotesDto), null);
        return Ok(recipe);
    }
    //todo comment, reply, rate, view profile, edit avatar, view liked recipes

}
