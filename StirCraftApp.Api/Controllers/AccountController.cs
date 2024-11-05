using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.DTOs.User;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController(SignInManager<AppUser> signInManager) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        //todo check if user already exists or email
        var user = new AppUser
        {
            DisplayName = userRegisterDto.DisplayName,
            Email = userRegisterDto.Email,
            UserName = userRegisterDto.Email
        };

        var result = await signInManager.UserManager.CreateAsync(user, userRegisterDto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Ok(); //or no content?
    }
}
