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
    private readonly Mock<UserManager<AppUser>> _userManagerMock;
    private readonly Mock<ICookService> _cookServiceMock;
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
        var userStoreMock = new Mock<IUserStore<AppUser>>();
        _userManagerMock = new Mock<UserManager<AppUser>>(
            userStoreMock.Object, null, null, null, null, null, null, null, null);
        _cookServiceMock = new Mock<ICookService>();
        _accountService = new AccountService(_userManagerMock.Object, _cookServiceMock.Object);

    }
    [Fact]
    public async Task RegisterUserAsync_UniqueDisplayName_SuccessfulRegistration()
    {
        _userManagerMock
            .Setup(um => um.Users)
            .Returns(new List<AppUser>().AsQueryable());

        _userManagerMock
            .Setup(um => um.CreateAsync(It.IsAny<AppUser>(), _userRegisterDto.Password))
            .ReturnsAsync(IdentityResult.Success);

        _userManagerMock
            .Setup(um => um.AddToRoleAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);

        var result = await _accountService.RegisterUserAsync(_userRegisterDto);

        Assert.Empty(result);
        _userManagerMock.Verify(um => um.CreateAsync(It.Is<AppUser>(u =>
            u.DisplayName == _userRegisterDto.DisplayName &&
            u.Email == _userRegisterDto.Email),
            _userRegisterDto.Password), Times.Once);
        _userManagerMock.Verify(um => um.AddToRoleAsync(It.IsAny<AppUser>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task RegisterUserAsync_DuplicateDisplayName_ReturnsError()
    {
        var existingUsers = new List<AppUser>
        {
            AppUser
        }.AsQueryable();

        _userManagerMock
            .Setup(um => um.Users)
            .Returns(existingUsers);

        var result = await _accountService.RegisterUserAsync(_userRegisterDto);

        Assert.Single(result);
        Assert.Equal("DisplayName", result[0].Code);
        Assert.Contains("display name is already taken", result[0].Description);
        _userManagerMock.Verify(um => um.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task GetUserInfoAsync_AuthenticatedUser_ReturnsUserInfo()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Email, "user@example.com"),
            new Claim(ClaimTypes.Role, "User")
        }, "TestAuthentication"));


        _userManagerMock
            .Setup(um => um.FindByEmailAsync(AppUser.Email!))
            .ReturnsAsync(AppUser);

        _cookServiceMock
            .Setup(cs => cs.IsCookAsync(AppUser.Id))
            .ReturnsAsync(true);

        _cookServiceMock
            .Setup(cs => cs.GetCookIdAsync(AppUser.Id))
            .ReturnsAsync(_cook.Id);

        var result = await _accountService.GetUserInfoAsync(user);


        Assert.NotNull(result);
        Assert.Equal(AppUser.Id, result.UserId);
        Assert.Equal(AppUser.DisplayName, result.DisplayName);
        Assert.Equal(AppUser.Email, result.Email);
        Assert.Equal(_cook.Id, result.CookId);
        Assert.Equal("User", result.Role);
    }

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

        _userManagerMock
            .Setup(um => um.FindByIdAsync(AppUser.Id))
            .ReturnsAsync(AppUser);

        _userManagerMock
            .Setup(um => um.UpdateAsync(AppUser))
            .ReturnsAsync(IdentityResult.Success);

        await _accountService.UpdateAvatarAsync(AppUser.Id, avatarDto);

        Assert.Equal(avatarDto.ImageUrl, AppUser.AvatarUrl);
        _userManagerMock.Verify(um => um.UpdateAsync(AppUser), Times.Once);
    }

    [Fact]
    public async Task UpdateAvatarAsync_UserNotFound_ThrowsNotFoundException()
    {
        var userId = "nonexistent";
        var avatarDto = new AvatarUpdateDto { ImageUrl = "anyUrl" };

        _userManagerMock
            .Setup(um => um.FindByIdAsync(userId))
            .ReturnsAsync((AppUser)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _accountService.UpdateAvatarAsync(userId, avatarDto));
    }
}
