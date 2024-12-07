
using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Entities;


namespace StirCraftApp.Application.Services;
public class AccountService(UserManager<AppUser> userManager) : IAccountService
{
    //public async Task<Result> RegisterUserAsync(UserRegisterDto userRegisterDto)
    //{
    //    var isUniqueDisplayName = await IsUniqueDisplayName(userRegisterDto.DisplayName);

    //    if (!isUniqueDisplayName)
    //    {
    //        return new ValidationError("The display name is already taken. Please choose a different one.");
    //    }

    //    var user = new AppUser
    //    {
    //        DisplayName = userRegisterDto.DisplayName,
    //        Email = userRegisterDto.Email,
    //        UserName = userRegisterDto.Email
    //    };

    //    try
    //    {
    //        var createResult = await userManager.CreateAsync(user, userRegisterDto.Password);
    //        if (!createResult.Succeeded)
    //        {
    //            var errors = createResult.Errors.Select(e => e.Description);
    //            return new ValidationError($"Failed to create user: {string.Join(", ", errors)}");
    //        }

    //        var roleResult = await userManager.AddToRoleAsync(user, UserRoleName);

    //        if (!roleResult.Succeeded)
    //        {
    //            await userManager.DeleteAsync(user);
    //            return new ValidationError("Failed to assign user role");
    //        }

    //        return Result.Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ValidationError($"An unexpected error occurred: {ex.Message}");
    //    }
    //}

    //private async Task<bool> IsUniqueDisplayName(string desiredName)
    //{
    //    return !await userManager.Users.AnyAsync(u => u.DisplayName == desiredName);
    //}
}
