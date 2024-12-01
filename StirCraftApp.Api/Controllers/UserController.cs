using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IRecipeService recipeService, IUserService userService) : ControllerBase
{


    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = User.GetId();
        var dto = await userService.GetUserProfileAsync(userId);
        return Ok(dto);
    }


    //todo comment, reply, rate, view profile, edit avatar, view liked recipes


}
