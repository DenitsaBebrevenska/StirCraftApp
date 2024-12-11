using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
/// <summary>
/// Provides endpoints for user account management, including registration, login, logout, and profile updates.
/// </summary>
/// <remarks>
/// Inherits from the BaseApiController class, Authorize attribute is applied by default, unless overridden.
/// Routing is configured to use the "api/account" path.
/// This controller handles account-related operations for the StirCraft application. 
/// It supports user registration, authentication state retrieval, logout, avatar updates, and fetching user information.
/// </remarks>
public class AccountController(SignInManager<AppUser> signInManager, IAccountService accountService) : BaseApiController
{
    /// <summary>
    /// Registers a new user in the system. Allows anonymous access.
    /// </summary>
    /// <param name="userRegisterDto">The data transfer object containing user registration details.</param>
    /// <returns>
    /// Returns a 204 No Content status if registration is successful. 
    /// Returns a 400 Bad Request status with validation errors if the registration fails.
    /// </returns>
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

    /// <summary>
    /// Logs out the current user by terminating their session.
    /// </summary>
    /// <returns>
    /// Always returns a 204 No Content status on successful logout.
    /// </returns>
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }

    /// <summary>
    /// Retrieves the current user's information. Allows anonymous access.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with user details if available, otherwise returns a 204 No Content status.
    /// </returns>
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

    /// <summary>
    /// Updates the avatar for the currently authenticated user.
    /// </summary>
    /// <param name="avatarDto">The data transfer object containing the avatar update information.</param>
    /// <returns>
    /// Always returns a 204 No Content status on successful update.
    /// </returns>
    [Authorize]
    [HttpPut("avatar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAvatar(AvatarUpdateDto avatarDto)
    {
        var userId = User.GetId();

        await accountService.UpdateAvatarAsync(userId!, avatarDto);

        return NoContent();
    }

    /// <summary>
    /// Checks and returns the current user's authentication state. Allows anonymous access.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with a boolean indicating whether the user is authenticated.
    /// </returns>
    [AllowAnonymous]
    [HttpGet("auth")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public IActionResult GetAuthState()
    {
        return Ok(new { IsAuthenticated = User.Identity?.IsAuthenticated ?? false });
    }

}
