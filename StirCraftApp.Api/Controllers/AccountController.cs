using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Api.Extensions;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Infrastructure.Identity;
using System.Security.Claims;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController(SignInManager<AppUser> signInManager) : BaseApiController
{
    [AllowAnonymous]
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

    [HttpPost("avatar")]
    public async Task<IActionResult> AddOrUpdateAvatar(IFormFile file)
    {
        var user = await signInManager.UserManager.GetUserByEmail(User);

        //todo add image upload logic

        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }

    [AllowAnonymous]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated == false)
        {
            return NoContent();
        }

        var user = await signInManager.UserManager.GetUserByEmail(User);

        return Ok(
            new
            {
                user.DisplayName,
                user.Email,
                Roles = User.FindFirstValue(ClaimTypes.Role)
            });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAuthState()
    {
        return Ok(new { IsAuthenticated = User.Identity?.IsAuthenticated ?? false });
    }

    private async Task<bool> IsUniqueDisplayName(string desiredName)
    {
        var isUniqueDisplayName = await signInManager
            .UserManager
            .Users
            .AnyAsync(u => u.DisplayName == desiredName);

        return isUniqueDisplayName;
    }

}
