using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Domain.Entities;
using System.Security.Claims;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Application.Services;

/// <summary>
/// The AccountService class provides methods for managing user accounts, including user registration, 
/// retrieving user information, and updating avatar images. It implements the IAccountService interface. 
/// The service uses UserManager for user-related operations and ICookService for cook-specific functionality.
/// Implements IAccountService interface and uses UserManager and ICookService for user-related operations.
/// </summary>
public class AccountService(UserManager<AppUser> userManager, ICookService cookService) : IAccountService
{
    /// <summary>
    /// Registers a new user by checking if the desired display name is unique, creating 
    /// the user, and assigning a role.
    /// </summary>
    /// <param name="userRegisterDto">The data transfer object containing user registration details.</param>
    /// <returns>A list of Identity Errors if they occur or and empty list when registration is successful.</returns>
    public async Task<List<IdentityError>> RegisterUserAsync(UserRegisterDto userRegisterDto)
    {
        var isUniqueDisplayName = await IsUniqueDisplayName(userRegisterDto.DisplayName);

        if (!isUniqueDisplayName)
        {
            return new List<IdentityError>
           {
               new()
               {
                   Code = "DisplayName",
                   Description = "The display name is already taken. Please choose a different one."
               }
           };
        }

        var user = new AppUser
        {
            DisplayName = userRegisterDto.DisplayName,
            Email = userRegisterDto.Email,
            UserName = userRegisterDto.Email
        };

        var result = await userManager.CreateAsync(user, userRegisterDto.Password);

        if (!result.Succeeded)
        {
            return result.Errors.ToList();
        }

        await userManager.AddToRoleAsync(user, UserRoleName);

        return new List<IdentityError>();
    }

    /// <summary>
    /// Retrieves user information for an authenticated user, including display name, email, 
    /// avatar URL, and cook ID if applicable.
    /// </summary>
    /// <param name="user">The ClaimsPrincipal representing the currently authenticated user.</param>
    /// <returns>
    /// A UserInfoDto containing the user's details such as UserId, DisplayName, Email, AvatarUrl, CookId (if applicable), 
    /// and Role, or null if the user is not authenticated or the user does not exist.
    /// </returns>
    public async Task<UserInfoDto?> GetUserInfoAsync(ClaimsPrincipal? user)
    {
        if (user == null || !user.Identity?.IsAuthenticated == true)
        {
            return null;
        }

        var email = user.FindFirstValue(ClaimTypes.Email);
        var appUser = await userManager.FindByEmailAsync(email!);

        if (appUser == null)
        {
            return null;
        }

        return new UserInfoDto
        {
            UserId = appUser.Id,
            DisplayName = appUser.DisplayName,
            Email = appUser.Email,
            AvatarUrl = appUser.AvatarUrl,
            CookId = await cookService.IsCookAsync(appUser.Id)
                ? await cookService.GetCookIdAsync(appUser.Id)
                : null,
            Role = user.FindFirstValue(ClaimTypes.Role)
        };
    }

    /// <summary>
    /// Updates the avatar URL for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user whose avatar is to be updated.</param>
    /// <param name="avatarDto">The AvatarUpdateDto containing the new avatar image URL.</param>
    /// <exception cref="NotFoundException">Thrown when the user with the specified ID is not found.</exception>
    public async Task UpdateAvatarAsync(string userId, AvatarUpdateDto avatarDto)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(AppUser), userId));
        }

        user.AvatarUrl = avatarDto.ImageUrl;

        await userManager.UpdateAsync(user);

    }

    /// <summary>
    /// A helper method to check if the display name is unique across users in the system.
    /// </summary>
    /// <param name="desiredName">The name the user desires to use as Display Name.</param>
    /// <returns>A boolean result indicating whether the desired username is already taken.</returns>
    private async Task<bool> IsUniqueDisplayName(string desiredName)
    {
        var isUniqueDisplayName = await userManager
            .Users
            .AllAsync(u => u.DisplayName != desiredName);

        return isUniqueDisplayName;
    }

}
