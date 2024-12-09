using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.IngredientSpec;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using static StirCraftApp.Domain.Constants.CachingValues;
using static StirCraftApp.Domain.Constants.RoleConstants;



namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = AdminRoleName)]
public class AdminController(IIngredientService ingredientService, IRecipeService recipeService, UserManager<AppUser> userManager) : BaseApiController
{
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [HttpGet("ingredients")]
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientAdminPanelSpecParams specParams)
    {
        var spec = new IngredientFilterAdminPanelSpecification(specParams);
        var ingredients = await ingredientService
            .GetIngredientsAsync(spec, ingredient => ingredient
                .ToBriefIngredientDto());

        return Ok(ingredients);
    }

    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [HttpGet("ingredients/{id}")]
    public async Task<IActionResult> GetIngredient(int id)
    {
        var ingredient = await ingredientService
            .GetIngredientByIdAsync(id, null, ingredient => ingredient
                .ToEditFormIngredientDto());

        return Ok(ingredient);
    }

    [HttpPost("ingredients")]
    public async Task<IActionResult> AddIngredient(FormIngredientDto ingredientDto)
    {
        await ingredientService.CreateIngredientAsync(ingredientDto);
        return Ok(); //todo return created ingredient
    }

    [HttpPut("ingredients/{id}")]
    public async Task<IActionResult> UpdateOrApproveIngredient(EditFormIngredientDto ingredientDto, int id)
    {
        await ingredientService.UpdateIngredientAsync(ingredientDto, id);
        return Ok();
    }

    [HttpDelete("ingredients/{id}")]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
        await ingredientService.DeleteIngredientAsync(id);
        return Ok();
    }

    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [HttpGet("recipes/pending-approval")]
    public async Task<IActionResult> GetRecipesPendingApproval([FromQuery] PagingParams pagingParams)
    {
        var spec = new RecipePendingApprovalBriefSpecification(pagingParams);
        var recipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToBriefRecipeDtoAsync(userManager));
        return Ok(recipes);
    }

    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [HttpGet("recipes/pending-approval/{id}")]
    public async Task<IActionResult> GetRecipePendingApproval(int id)
    {
        var spec = new RecipePendingApprovalSpecification();
        var recipe = await recipeService
            .GetRecipeByIdAsync(spec, id, async recipe => await recipe
                .ToDetailedRecipeAdminNotesDtoAsync(userManager));
        return Ok(recipe);
    }


    [HttpPut("recipes/pending-approval/{id}/notes")] //or patch
    public async Task<IActionResult> UpdateAdminNotesOnRecipe(int id, AdminNotesDto adminNotesDto)
    {
        await recipeService.UpdateAdminNotesAsync(id, adminNotesDto);
        return Ok(); //no content probably
    }

    [HttpPost("recipes/pending-approval/{id}/approve")]
    public async Task<IActionResult> ApproveRecipe(int id)
    {
        await recipeService.ApproveRecipeAsync(id);
        return Ok();
    }

}
