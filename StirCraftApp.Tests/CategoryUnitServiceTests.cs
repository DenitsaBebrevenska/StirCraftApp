using Moq;
using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using Xunit;

namespace StirCraftApp.Tests;
public class CategoryUnitServiceTests
{
    private readonly Mock<IRepository<Category>> _mockRepository;
    private readonly CategoryService _service;
    private const int TestId1 = 1;
    private const string TestUnitName1 = "Cat1";
    private const int TestId2 = 2;
    private const string TestUnitName2 = "Cat2";

    public CategoryUnitServiceTests()
    {
        Mock<IUnitOfWork> mockUnitOfWork = new();
        _mockRepository = new Mock<IRepository<Category>>();
        mockUnitOfWork.Setup(u => u.Repository<Category>()).Returns(_mockRepository.Object);
        _service = new CategoryService(mockUnitOfWork.Object);
    }

    [Fact]
    public async Task GetCategoriesNamesAsync_ReturnsCategoryNames()
    {
        var categories = new List<Category>
        {
            new() { Id = TestId1, Name = TestUnitName1 },
            new() { Id = TestId2, Name = TestUnitName2 }
        };

        _mockRepository.Setup(r => r
            .GetAllAsync(null))
            .ReturnsAsync(categories);


        var result = await _service.GetCategoriesNamesAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(TestUnitName1, result);
        Assert.Contains(TestUnitName2, result);
    }

    [Fact]
    public async Task GetCategoriesNamesAsync_NoCategories_ReturnsEmptyList()
    {
        var categories = new List<Category>();

        _mockRepository
            .Setup(x => x.GetAllAsync(null))
            .ReturnsAsync(categories);

        var result = await _service.GetCategoriesNamesAsync();

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAll_ReturnsCategoryDtos()
    {
        var categories = new List<Category>
        {
            new() { Id = TestId1, Name = TestUnitName1 },
            new() { Id = TestId2, Name = TestUnitName2 }
        };

        _mockRepository.Setup(r => r
            .GetAllAsync(null))
            .ReturnsAsync(categories);

        var expectedDtos = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();

        var result = await _service.GetAll();

        Assert.NotNull(result);

        for (int i = 0; i < expectedDtos.Count; i++)
        {
            Assert.Equal(expectedDtos[i].Id, result[i].Id);
            Assert.Equal(expectedDtos[i].Name, result[i].Name);
        }
    }

    [Fact]
    public async Task GetAll_VerifyRepositoryMethodCalled()
    {
        var categories = new List<Category>
        {
            new () { Id = TestId1, Name = TestUnitName1 }
        };

        _mockRepository
            .Setup(x => x.GetAllAsync(null))
            .ReturnsAsync(categories);

        await _service.GetAll();

        _mockRepository.Verify(
            x => x.GetAllAsync(null),
            Times.Once
        );
    }
}

