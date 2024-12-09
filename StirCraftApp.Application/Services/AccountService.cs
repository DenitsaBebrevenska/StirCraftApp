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
public class AccountService(UserManager<AppUser> userManager, ICookService cookService) : IAccountService
{
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

    private async Task<bool> IsUniqueDisplayName(string desiredName)
    {
        var isUniqueDisplayName = await userManager
            .Users
            .AllAsync(u => u.DisplayName != desiredName);

        return isUniqueDisplayName;
    }

}
