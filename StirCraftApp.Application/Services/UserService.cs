using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;
public class UserService(UserManager<AppUser> userManager, IUnitOfWork unit) : IUserService
{
    public async Task<UserProfileDto> GetUserProfileAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        var cooks = await unit.Repository<Cook>().GetAllAsync(null);
        var isCook = cooks.Any(c => c.UserId == userId);

        var userProfile = new UserProfileDto
        {
            DisplayName = user.DisplayName!,
            Email = user.Email!,
            AvatarUrl = user.AvatarUrl,
            IsCook = isCook
        };

        return userProfile;
    }
}
