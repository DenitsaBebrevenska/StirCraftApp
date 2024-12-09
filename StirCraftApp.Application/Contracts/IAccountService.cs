using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.DTOs.UserDtos;
using System.Security.Claims;

namespace StirCraftApp.Application.Contracts;
public interface IAccountService
{
    Task<List<IdentityError>> RegisterUserAsync(UserRegisterDto userRegisterDto);

    Task UpdateAvatarAsync(string userId, AvatarUpdateDto avatarDto);

    Task<UserInfoDto?> GetUserInfoAsync(ClaimsPrincipal? user);
}
