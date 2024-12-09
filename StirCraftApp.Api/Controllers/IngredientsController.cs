using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Mappings;
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
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientSpecParams specParams)
    {
        var spec = new IngredientFilterAdminApprovedSpecification(specParams);
        return Ok(await ingredientService
            .GetIngredientsAsync(spec, ingredient => ingredient
                .ToBriefIngredientDto()));
    }

    [HttpGet("all")]
    [AllowAnonymous]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetIngredientsAllNonPaged()
    {
        return Ok(await ingredientService.GetIngredientsNotPaged());
    }

    [InvalidateCache(IngredientsAdminCachePattern)]
    [Authorize(Roles = CookRoleName)]
    [HttpPost("suggest")]
    public async Task<IActionResult> SuggestIngredient(SuggestIngredientDto dto)
    {
        await ingredientService.SuggestIngredient(dto);
        return NoContent();
    }
}
