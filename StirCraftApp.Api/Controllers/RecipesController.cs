using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService recipeService, ICookService cookService) : ControllerBase
{
    // get recipes with specs and not, get recipe by id, create recipe, edit recipe, delete recipe
    [HttpGet]
    public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams specParams)
    {
        var spec = new RecipeFilterSortIncludeSpecification(specParams);
        var recipes = await recipeService.GetRecipesAsync(spec, nameof(SummaryRecipeDto));
        return Ok(recipes);
    }

    [HttpGet("top/{count}")]
    public async Task<IActionResult> GetTopNRecipes(int count)
    {
        var recipes = await recipeService.GetTopNRecipes(count, nameof(BriefRecipeDto));
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var spec = new RecipeIncludeAllApprovedSpecification();
        var recipe = await recipeService.GetRecipeByIdAsync(spec, id, nameof(DetailedRecipeDto));
        return Ok(recipe);
    }

    [HttpGet("cook/{id}")]
    public async Task<IActionResult> GetRecipesByCookId(int id, [FromQuery] PagingParams pagingParams)
    {
        var spec = new RecipeByCookIdSpecification(pagingParams, id);
        var cookRecipes = await recipeService.GetRecipesAsync(spec, nameof(CookRecipeSummaryDto));
        return Ok(cookRecipes);
    }

    //implementing that through any service is not necessary, complicates it for no good reason
    [HttpGet("difficultyLevels")]
    public IActionResult GetDifficultyLevels()
    {
        var difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        return Ok(difficultyLevels);
    }

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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecipe(int id, EditFormRecipeDto updateRecipeDto)
    {
        if (updateRecipeDto.Id != id)
        {
            return BadRequest("Id in the body does not match the id in the route");
        }

        await recipeService.UpdateRecipeAsync(updateRecipeDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await recipeService.DeleteRecipeAsync(id);
        return Ok();
    }


}
