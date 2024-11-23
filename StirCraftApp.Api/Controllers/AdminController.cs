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

    [HttpGet]
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientSpecParams specParams)
    {
        var spec = new IngredientFilterAdminApprovedSpecification(specParams);
        var ingredients = await ingredientService.GetIngredientsAsync(spec);

        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredient(int id)
    {
        var ingredient = await ingredientService.GetIngredientByIdAsync(id);

        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<IActionResult> AddIngredient(FormIngredientDto ingredientDto)
    {
        await ingredientService.CreateIngredientAsync(ingredientDto);
        return Ok(); //todo return created ingredient
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrApproveIngredient(int id)
    {
        //await ingredientService.UpdateIngredientAsync(id);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
        await ingredientService.DeleteIngredientAsync(id);
        return Ok();
    }
}
