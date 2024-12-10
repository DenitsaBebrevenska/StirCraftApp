using Microsoft.AspNetCore.Identity;
using Moq;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using Xunit;

namespace StirCraftApp.Tests;
public class CookUnitServiceTests
{
    private readonly Mock<IRepository<Cook>> _cookRepositoryMock;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<UserManager<AppUser>> _mockUserManager;
    private readonly CookService _cookService;
    private const string TestUserNonExistingId = "NonExistant";
    private const string TestUser1Id = "testUser1";
    private const string TestAbout1 = "Test About for User 1";
    private const string TestUser2Id = "testUser2";
    private const string TestAbout2 = "Test About for User 2";
    private const int TestRecipeId1 = 42;
    private const int TestRecipeId2 = 82;
    private const int TestCook1Id = 1;
    private const int TestCook2Id = 2;
    private readonly List<Cook> _cooks = [];
    private readonly Recipe _testRecipe1 = new()
    {
        Id = TestRecipeId1,
        Name = "Test Recipe",
        PreparationSteps = "Test Description",
    };
    private readonly Recipe _testRecipe2 = new()
    {
        Id = TestRecipeId2,
        Name = "Test Recipe2",
        PreparationSteps = "Test Description2",
    };
    public CookUnitServiceTests()
    {
        var userStoreMock = new Mock<IUserStore<AppUser>>();
        _mockUserManager = new Mock<UserManager<AppUser>>(
            userStoreMock.Object, null, null, null, null, null, null, null, null);


        _cookRepositoryMock = new Mock<IRepository<Cook>>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockUnitOfWork.Setup(u => u.Repository<Cook>()).Returns(_cookRepositoryMock.Object);

        _cookService = new CookService(_mockUnitOfWork.Object, _mockUserManager.Object);

    }

    #region GetCookIdAsync Tests
    [Fact]
    public async Task GetCookIdAsync_ExistingUser_ReturnsCookId()
    {
        _cooks.Add(new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1
        });

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);

        var result = await _cookService.GetCookIdAsync(TestUser1Id);

        Assert.Equal(TestCook1Id, result);
    }

    [Fact]
    public async Task GetCookIdAsync_NonExistingUser_ThrowsValidationException()
    {
        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);

        await Assert.ThrowsAsync<ValidationException>(
            () => _cookService.GetCookIdAsync(TestUserNonExistingId));
    }
    #endregion

    #region GetCookAboutAsync Tests
    [Fact]
    public async Task GetCookAboutAsync_ExistingUser_ReturnsCookAboutDto()
    {
        _cooks.Add(new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1
        });

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);

        var result = await _cookService.GetCookAboutAsync(TestUser1Id);

        Assert.Equal(TestAbout1, result.About);
    }


    [Fact]
    public async Task GetCookAboutAsync_NonExistingUser_ThrowsValidationException()
    {
        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);

        await Assert.ThrowsAsync<ValidationException>(
            () => _cookService.GetCookAboutAsync(TestUserNonExistingId));
    }
    #endregion

    #region BecomeCookAsync Tests
    [Fact]
    public async Task BecomeCookAsync_UserNotAlreadyCook_SuccessfullyBecomesCook()
    {
        var userId = TestUser1Id;
        var aboutDto = new CookAboutDto { About = TestAbout1 };
        var user = new AppUser { Id = TestUser1Id };

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);
        _cookRepositoryMock.Setup(c => c.AddAsync(It.IsAny<Cook>()))
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        _mockUserManager.Setup(x => x.FindByIdAsync(userId))
            .ReturnsAsync(user);
        _mockUserManager.Setup(x => x.AddToRoleAsync(user, "Cook"))
            .Returns(Task.FromResult(IdentityResult.Success));
        _mockUserManager.Setup(x => x.RemoveFromRoleAsync(user, "User"))
            .Returns(Task.FromResult(IdentityResult.Success));

        await _cookService.BecomeCookAsync(aboutDto, userId);

        _cookRepositoryMock.Verify(c => c.AddAsync(It.Is<Cook>(
            ck => ck.UserId == userId && ck.About == aboutDto.About)), Times.Once);
        _mockUserManager.Verify(x => x.AddToRoleAsync(user, "Cook"), Times.Once);
        _mockUserManager.Verify(x => x.RemoveFromRoleAsync(user, "User"), Times.Once);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }


    [Fact]
    public async Task BecomeCookAsync_UserAlreadyCook_ThrowsValidationException()
    {

        var aboutDto = new CookAboutDto { About = TestAbout1 };
        _cooks.Add(new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1
        });

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);

        await Assert.ThrowsAsync<ValidationException>(
            () => _cookService.BecomeCookAsync(aboutDto, TestUser1Id));
    }
    #endregion

    #region UpdateAboutAsync Tests
    [Fact]
    public async Task UpdateAboutAsync_ExistingCook_UpdatesAboutSuccessfully()
    {
        var cook = new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1
        };
        _cooks.Add(cook);

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);
        _cookRepositoryMock.Setup(c => c.Update(It.IsAny<Cook>()));
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        var aboutDto = new CookAboutDto { About = TestAbout2 };

        await _cookService.UpdateAboutAsync(TestUser1Id, aboutDto);

        Assert.Equal(TestAbout2, cook.About);
        _cookRepositoryMock.Verify(c => c.Update(cook), Times.Once);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAboutAsync_NonExistingCook_ThrowsValidationException()
    {
        var cooks = new List<Cook>();

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(cooks);

        var aboutDto = new CookAboutDto { About = TestAbout1 };

        await Assert.ThrowsAsync<ValidationException>(
            () => _cookService.UpdateAboutAsync(TestUserNonExistingId, aboutDto));
    }
    #endregion

    #region CookIsTheRecipeOwner Tests
    [Fact]
    public async Task CookIsTheRecipeOwner_CookOwnsRecipe_ReturnsTrue()
    {
        var cook = new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1,
            Recipes = new List<Recipe> { _testRecipe1 }
        };

        var spec = new CookIncludeAllSpecification();
        _cookRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<CookIncludeAllSpecification>(), cook.Id))
            .ReturnsAsync(cook);

        var result = await _cookService.CookIsTheRecipeOwner(TestCook1Id, _testRecipe1.Id);

        Assert.True(result);

    }


    [Fact]
    public async Task CookIsTheRecipeOwner_CookDoesNotOwnRecipe_ReturnsFalse()
    {
        var cook = new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1,
        };

        cook.Recipes.Add(_testRecipe1);

        _testRecipe2.CookId = TestCook2Id;

        _cookRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<CookIncludeAllSpecification>(), cook.Id))
            .ReturnsAsync(cook);

        var result = await _cookService.CookIsTheRecipeOwner(cook.Id, _testRecipe2.Id);

        Assert.False(result);
    }
    [Fact]
    public async Task CookIsTheRecipeOwner_CookNotFound_ThrowsNotFoundException()
    {
        var cookId = TestCook1Id;
        var recipeId = TestRecipeId1;

        _cookRepositoryMock.Setup(c => c.GetByIdAsync(It.IsAny<CookIncludeAllSpecification>(), cookId))
            .ReturnsAsync((Cook)null);

        await Assert.ThrowsAsync<NotFoundException>(
            () => _cookService.CookIsTheRecipeOwner(cookId, recipeId));
    }
    #endregion


    #region IsCookAsync Tests
    [Fact]
    public async Task IsCookAsync_UserIsCook_ReturnsTrue()
    {
        var cook = new Cook
        {
            Id = TestCook1Id,
            UserId = TestUser1Id,
            About = TestAbout1,
        };
        _cooks.Add(cook);

        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);


        var result = await _cookService.IsCookAsync(cook.UserId);

        Assert.True(result);
    }

    [Fact]
    public async Task IsCookAsync_UserIsNotCook_ReturnsFalse()
    {
        _cookRepositoryMock.Setup(c => c.GetAllAsync(null))
            .ReturnsAsync(_cooks);

        var result = await _cookService.IsCookAsync(TestUser2Id);

        Assert.False(result);
    }
    #endregion
}
