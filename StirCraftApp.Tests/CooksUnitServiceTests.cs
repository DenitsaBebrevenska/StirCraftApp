using Moq;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using Xunit;

namespace StirCraftApp.Tests;
public class CooksUnitServiceTests
{
    private readonly Mock<IRepository<Cook>> _mockCookRepository;
    private readonly CooksService _cooksService;
    private static readonly Cook TestCook1 = new()
    {
        Id = 1,
        About = "Test About1",
        UserId = "testUser1",
        AppUser = new AppUser
        {
            DisplayName = "John Doe"
        },
        CookingRank = new CookingRank
        {
            Id = 1,
            Title = "Noob"
        }
    };
    private static readonly Cook TestCook2 = new()
    {
        Id = 2,
        About = "Test About2",
        UserId = "testUser2",
        AppUser = new AppUser
        {
            DisplayName = "Jane Doe"
        },
        CookingRank = new CookingRank
        {
            Id = 1,
            Title = "Noob"
        }
    };

    private readonly List<Cook> _cooks =
    [
        TestCook1,
        TestCook2
    ];

    private readonly Func<Cook, Task<DetailedCookDto>> _convertFunc = c => Task.FromResult(new DetailedCookDto
    {
        Id = c.Id,
        About = c.About,
        DisplayName = c.AppUser.DisplayName!,
        CookingRank = c.CookingRank.Title.ToString()
    });

    public CooksUnitServiceTests()
    {
        Mock<IUnitOfWork> mockUnitOfWork = new();
        _mockCookRepository = new Mock<IRepository<Cook>>();

        mockUnitOfWork.Setup(uow => uow.Repository<Cook>())
            .Returns(_mockCookRepository.Object);

        _cooksService = new CooksService(mockUnitOfWork.Object);
    }

    #region GetCookByIdAsync Tests

    [Fact]
    public async Task GetCookByIdAsync_ExistingCook_ReturnsDto()
    {

        var expectedDto = new DetailedCookDto
        {
            Id = TestCook1.Id,
            About = TestCook1.About,
            DisplayName = "John Doe",
            CookingRank = "Noob"
        };

        _mockCookRepository.Setup(r => r.GetByIdAsync(
            It.IsAny<CookIncludeAllSpecification>(),
            TestCook1.Id))
            .ReturnsAsync(TestCook1);

        var result = await _cooksService.GetCookByIdAsync(TestCook1.Id, _convertFunc);

        Assert.NotNull(result);
        Assert.Equal(TestCook1.Id, result.Id);
        Assert.Equal(TestCook1.About, result.About);
        Assert.Equal(expectedDto.DisplayName, result.DisplayName);
        Assert.Equal(expectedDto.CookingRank, result.CookingRank);
    }

    [Fact]
    public async Task GetCookByIdAsync_NonExistingCook_ThrowsNotFoundException()
    {
        _mockCookRepository.Setup(r => r.GetByIdAsync(
            It.IsAny<CookIncludeAllSpecification>(),
            TestCook2.Id))
            .ReturnsAsync((Cook)null);


        await Assert.ThrowsAsync<NotFoundException>(() =>
            _cooksService.GetCookByIdAsync(TestCook1.Id, _convertFunc));
    }

    #endregion

    #region GetCooksAsync Tests

    [Fact]
    public async Task GetCooksAsync_ReturnsCorrectPaginatedResult()
    {
        var spec = new Mock<ISpecification<Cook>>().Object;

        _mockCookRepository.Setup(r => r.GetAllAsync(spec))
            .ReturnsAsync(_cooks);
        _mockCookRepository.Setup(r => r.CountAsync(spec))
            .ReturnsAsync(2);

        var result = await _cooksService.GetCooksAsync(spec, _convertFunc);

        Assert.NotNull(result);
        Assert.Equal(2, result.Data.Count);
    }

    [Fact]
    public async Task GetCooksAsync_EmptyList_ReturnsEmptyPaginatedResult()
    {
        var spec = new Mock<ISpecification<Cook>>().Object;


        _mockCookRepository.Setup(r => r.GetAllAsync(spec))
            .ReturnsAsync(new List<Cook>());
        _mockCookRepository.Setup(r => r.CountAsync(spec))
            .ReturnsAsync(0);

        var result = await _cooksService.GetCooksAsync(spec, _convertFunc);

        Assert.NotNull(result);
        Assert.Empty(result.Data);
    }

    #endregion
}

