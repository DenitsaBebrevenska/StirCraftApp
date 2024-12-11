using Microsoft.AspNetCore.Identity;
using Moq;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.UserDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Entities;
using System.Security.Claims;
using Xunit;

namespace StirCraftApp.Tests;
public class AccountUnitServiceTests
{
    private readonly Mock<UserManager<AppUser>> _mockUserManager;
    private readonly AccountService _accountService;
    private readonly UserRegisterDto _userRegisterDto = new()
    {
        DisplayName = "UniqueDisplayName",
        Email = "test@example.com",
        Password = "P@ssword1"
    };

    private static readonly AppUser AppUser = new()
    {
        Id = "777",
        DisplayName = "TestUser",
        Email = "test@example.com",
        AvatarUrl = "avatar.png"
    };

    private readonly Cook _cook = new()
    {
        Id = 1,
        UserId = "777",
        AppUser = AppUser,
        About = "test"
    };

    public AccountUnitServiceTests()
    {
        _mockUserManager = new Mock<UserManager<AppUser>>(
            Mock.Of<IUserStore<AppUser>>(),
            null, null, null, null, null, null, null, null
        );
        Mock<ICookService> cookServiceMock = new();
        _accountService = new AccountService(_mockUserManager.Object, cookServiceMock.Object);

    }

    //todo figure out a way to test out the registration as all mocks of user manager for it failed

    [Fact]
    public async Task GetUserInfoAsync_UnauthenticatedUser_ReturnsNull()
    {
        var unauthenticatedUser = new ClaimsPrincipal();

        var result = await _accountService.GetUserInfoAsync(unauthenticatedUser);

        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateAvatarAsync_UserExists_UpdatesAvatar()
    {
        var avatarDto = new AvatarUpdateDto { ImageUrl = "anyUrl" };

        AppUser.AvatarUrl = "oldUrl";

        _mockUserManager
            .Setup(um => um.FindByIdAsync(AppUser.Id))
            .ReturnsAsync(AppUser);

        _mockUserManager
            .Setup(um => um.UpdateAsync(AppUser))
            .ReturnsAsync(IdentityResult.Success);

        await _accountService.UpdateAvatarAsync(AppUser.Id, avatarDto);

        Assert.Equal(avatarDto.ImageUrl, AppUser.AvatarUrl);
        _mockUserManager.Verify(um => um.UpdateAsync(AppUser), Times.Once);
    }

    [Fact]
    public async Task UpdateAvatarAsync_UserNotFound_ThrowsNotFoundException()
    {
        var userId = "nonexistent";
        var avatarDto = new AvatarUpdateDto { ImageUrl = "anyUrl" };

        _mockUserManager
            .Setup(um => um.FindByIdAsync(userId))
            .ReturnsAsync((AppUser)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _accountService.UpdateAvatarAsync(userId, avatarDto));
    }

}
