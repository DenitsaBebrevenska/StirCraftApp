using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Extensions;


namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController(SignInManager<AppUser> signInManager, IAccountService accountService) : BaseApiController
{
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        var errors = await accountService.RegisterUserAsync(userRegisterDto);

        if (errors.Any())
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        return NoContent();
    }


    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }


    [AllowAnonymous]
    [HttpGet("user-info")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(UserInfoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserInfo()
    {
        var userInfo = await accountService.GetUserInfoAsync(User);

        if (userInfo == null)
        {
            return NoContent();
        }

        return Ok(userInfo);
    }

    [Authorize]
    [HttpPut("avatar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAvatar(AvatarUpdateDto avatarDto)
    {
        var userId = User.GetId();

        await accountService.UpdateAvatarAsync(userId!, avatarDto);

        return NoContent();
    }


    [AllowAnonymous]
    [HttpGet("auth")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public IActionResult GetAuthState()
    {
        return Ok(new { IsAuthenticated = User.Identity?.IsAuthenticated ?? false });
    }

}
