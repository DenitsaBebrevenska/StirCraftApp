using Castle.Components.DictionaryAdapter;
using Moq;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using Xunit;
using static StirCraftApp.Domain.Constants.RankingConstants;

namespace StirCraftApp.Tests;
public class CookingRankUnitServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IRepository<Cook>> _mockCookRepository;
    private readonly Mock<IRepository<CookingRank>> _mockRankRepository;
    private readonly CookingRankService _service;

    private const string LikeConstant = LikingARecipe;
    private const string UnlikeConstant = UnlikingARecipe;
    private const string UploadConstant = UploadingARecipe;
    private const string DeleteConstant = DeletingARecipe;
    private const string InvalidAction = "InvalidAction";
    private const uint LikeValueConstant = RecipeLikeRankingPointsValue;
    private const uint UploadValueConstant = RecipeUploadRankingPointsValue;

    private static readonly List<CookingRank> TestRanks = new EditableList<CookingRank>
    {
        new() { Id = 1, Title = "TestRank1", RequiredPoints = 0 },
        new () { Id = 2, Title = "TestRank2", RequiredPoints = 100 },
        new () { Id = 3, Title = "TestRank3", RequiredPoints = 500 }
    };

    private const int TestCookId = 1;
    private const int TestInvalidCookId = 999;
    private readonly Cook _testCook = new()
    {
        Id = TestCookId,
        RankingPoints = 50,
        CookingRankId = 1,
        CookingRank = TestRanks[0],
        About = "",
        UserId = 777.ToString()
    };


    public CookingRankUnitServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockCookRepository = new Mock<IRepository<Cook>>();
        _mockRankRepository = new Mock<IRepository<CookingRank>>();

        _mockUnitOfWork
            .Setup(x => x.Repository<Cook>())
            .Returns(_mockCookRepository.Object);
        _mockUnitOfWork
            .Setup(x => x.Repository<CookingRank>())
            .Returns(_mockRankRepository.Object);

        _service = new CookingRankService(_mockUnitOfWork.Object);
    }

    #region CalculatePoints Tests
    [Theory]
    [InlineData(LikingARecipe, LikeValueConstant)]
    [InlineData(UnlikingARecipe, -LikeValueConstant)]
    [InlineData(UploadingARecipe, UploadValueConstant)]
    [InlineData(DeletingARecipe, -UploadValueConstant)]
    public async Task CalculatePoints_ValidActions_UpdatesPointsCorrectly(string action, int expectedPointChange)
    {
        var cook = _testCook;
        var initialPoints = cook.RankingPoints;

        _mockCookRepository
            .Setup(x => x.GetByIdAsync(null, cook.Id))
            .ReturnsAsync(cook);

        _mockRankRepository
            .Setup(x => x.GetAllAsync(null))
            .ReturnsAsync(TestRanks);

        await _service.CalculatePoints(TestCookId, action);
        var expectedResult = initialPoints + expectedPointChange < 0 ? 0 : initialPoints + expectedPointChange;

        Assert.Equal(expectedResult, cook.RankingPoints);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }


    [Fact]
    public async Task CalculatePoints_NonExistentCook_ThrowsNotFoundException()
    {
        _mockCookRepository
            .Setup(x => x.GetByIdAsync(null, TestInvalidCookId))
            .ReturnsAsync((Cook)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _service.CalculatePoints(TestInvalidCookId, LikeConstant));
    }

    [Fact]
    public async Task CalculatePoints_InvalidAction_ThrowsArgumentException()
    {
        var cook = _testCook;

        _mockCookRepository
            .Setup(x => x.GetByIdAsync(null, cook.Id))
            .ReturnsAsync(cook);

        await Assert.ThrowsAsync<ArgumentException>(() =>
            _service.CalculatePoints(cook.Id, InvalidAction));
    }
    #endregion

    #region RecalculateRank Tests
    [Fact]
    public async Task RecalculateRank_PointsBelowCurrentRank_DecreasesRank()
    {
        _testCook.RankingPoints = 100;
        _testCook.CookingRank = TestRanks[1];
        _testCook.CookingRankId = 2;

        _mockCookRepository
            .Setup(x => x.GetByIdAsync(null, _testCook.Id))
            .ReturnsAsync(_testCook);

        _mockRankRepository
            .Setup(x => x.GetAllAsync(null))
            .ReturnsAsync(TestRanks);

        await _service.CalculatePoints(_testCook.Id, DeleteConstant);

        Assert.Equal(1, _testCook.CookingRankId); // Demoting
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task RecalculateRank_PointsAboveNextRank_IncreasesRank()
    {
        _testCook.RankingPoints = 450;
        _testCook.CookingRankId = 2;

        _mockRankRepository
            .Setup(x => x.GetAllAsync(null))
            .ReturnsAsync(TestRanks);
        _mockCookRepository
            .Setup(x => x.GetByIdAsync(null, _testCook.Id))
            .ReturnsAsync(_testCook);

        await _service.CalculatePoints(_testCook.Id, UploadConstant);

        Assert.Equal(3, _testCook.CookingRankId); // Promoting
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task RecalculateRank_AtHighestRank_DoesNotExceedMaxRank()
    {
        _testCook.RankingPoints = 1000;
        _testCook.CookingRankId = 3;

        _mockRankRepository
            .Setup(x => x.GetAllAsync(null))
            .ReturnsAsync(TestRanks);
        _mockCookRepository
            .Setup(x => x.GetByIdAsync(null, _testCook.Id))
            .ReturnsAsync(_testCook);

        await _service.CalculatePoints(_testCook.Id, UploadingARecipe);

        Assert.Equal(3, _testCook.CookingRankId); // Remains at highest rank
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }
    #endregion
}
