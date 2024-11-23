using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Specifications.IngredientSpec;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdminController(IIngredientService ingredientService) : ControllerBase
{

    [HttpGet("ingredients")]
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientAdminPanelSpecParams specParams)
    {
        var spec = new IngredientFilterAdminPanelSpecification(specParams);
        var ingredients = await ingredientService.GetIngredientsAsync(spec, nameof(BriefIngredientDto));

        return Ok(ingredients);
    }

    [HttpGet("ingredients/{id}")]
    public async Task<IActionResult> GetIngredient(int id)
    {
        var ingredient = await ingredientService.GetIngredientByIdAsync(id, null);

        return Ok(ingredient);
    }

    [HttpPost("ingredients/create")]
    public async Task<IActionResult> AddIngredient(FormIngredientDto ingredientDto)
    {
        await ingredientService.CreateIngredientAsync(ingredientDto);
        return Ok(); //todo return created ingredient
    }

    [HttpPut("ingredients/update/{id}")]
    public async Task<IActionResult> UpdateOrApproveIngredient(EditFormIngredientDto ingredientDto, int id)
    {
        await ingredientService.UpdateIngredientAsync(ingredientDto, id);
        return Ok();
    }

    [HttpDelete("ingredients/delete/{id}")]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
        await ingredientService.DeleteIngredientAsync(id);
        return Ok();
    }
}
