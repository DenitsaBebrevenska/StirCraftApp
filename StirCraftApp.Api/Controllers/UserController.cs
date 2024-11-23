using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Extensions;
using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IRecipeService recipeService) : ControllerBase
{

    [HttpPost("recipe-like/{id}")]
    public async Task<IActionResult> LikeRecipe(int id)
    {
        var userId = User.GetId();
        await recipeService.AddRecipeToUsersFavoritesAsync(userId, id);
        return Ok();
    }

    [HttpPost("recipe-unlike/{id}")]
    public async Task<IActionResult> UnlikeRecipe(int id)
    {
        var userId = User.GetId();
        await recipeService.RemoveRecipeToUsersFavoritesAsync(userId, id);
        return Ok();
    }


    //todo comment, reply, rate, view profile, edit avatar, view liked recipes


}
