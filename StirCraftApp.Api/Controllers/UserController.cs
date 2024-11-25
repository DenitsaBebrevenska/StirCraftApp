using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IRecipeService recipeService, IUserService userService) : ControllerBase
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

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.GetId();
        var dto = await userService.GetUserProfileAsync(userId);
        return Ok(dto);
    }


    //todo comment, reply, rate, view profile, edit avatar, view liked recipes


}
