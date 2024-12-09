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
[Route("api/[controller]")]
[ApiController]
public class IngredientsController(IIngredientService ingredientService) : BaseApiController
{
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

    [HttpGet("all")]
    [AllowAnonymous]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    [ProducesResponseType(typeof(IList<BriefIngredientDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetIngredientsAllNonPaged()
    {
        var nonPagedIngredients = await ingredientService.GetIngredientsNotPaged();
        return Ok(nonPagedIngredients);
    }

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
