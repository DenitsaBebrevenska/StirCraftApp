using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;
public class UserService(UserManager<AppUser> userManager) : IUserService
{
    public Task<UserInfoDto> GetUserProfileAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAvatarAsync(string userId, AvatarUpdateDto avatarDto)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.AvatarUrl = avatarDto.ImageUrl;

        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new Exception("Problem updating the avatar");
        }
    }
}
