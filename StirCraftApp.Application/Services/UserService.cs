using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;
public class UserService(UserManager<AppUser> userManager, IUnitOfWork unit) : IUserService
{
    public Task<UserInfoDto> GetUserProfileAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
