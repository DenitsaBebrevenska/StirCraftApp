using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CookController(IRecipeService recipeService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRecipe(FormRecipeDto createRecipeDto)
    {
        await recipeService.CreateRecipeAsync(createRecipeDto);
        //todo return created recipe
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecipe(int id, FormRecipeDto updateRecipeDto)
    {

        await recipeService.UpdateRecipeAsync(updateRecipeDto);
        //todo return updated recipe ???
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await recipeService.DeleteRecipeAsync(id);
        return Ok();
    }


    //todo comment, reply, rate, view profile, edit avatar, view liked recipes
}
