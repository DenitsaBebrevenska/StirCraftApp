using Moq;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using Xunit;

namespace StirCraftApp.Tests;
public class IngredientUnitServiceTests
{
    private readonly Mock<IRepository<Ingredient>> _mockIngredientRepository;
    private readonly IngredientService _ingredientService;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public IngredientUnitServiceTests()
    {
        _mockUnitOfWork = new();
        _mockIngredientRepository = new Mock<IRepository<Ingredient>>();

        _mockUnitOfWork.Setup(uow => uow.Repository<Ingredient>())
            .Returns(_mockIngredientRepository.Object);

        _ingredientService = new IngredientService(_mockUnitOfWork.Object);
    }

    private readonly Func<Ingredient, EditFormIngredientDto> _convertFunc = i => new EditFormIngredientDto
    {
        Id = i.Id,
        Name = i.Name
    };

    private static readonly Ingredient TestIngredient1 = new Ingredient { Id = 1, Name = "Salt", IsAllergen = true, IsAdminApproved = true };
    private static readonly Ingredient TestIngredient2 = new Ingredient { Id = 2, Name = "Pepper", IsAllergen = false, IsAdminApproved = true };

    private readonly IList<Ingredient> _testIngredients = new List<Ingredient>
    {

        TestIngredient1,
        TestIngredient2
    };


    #region GetIngredientByIdAsync Tests

    [Fact]
    public async Task GetIngredientByIdAsync_ExistingIngredient_ReturnsDto()
    {
        _mockIngredientRepository.Setup(r => r.GetByIdAsync(
            It.IsAny<ISpecification<Ingredient>>(),
            TestIngredient1.Id))
            .ReturnsAsync(TestIngredient1);

        var result = await _ingredientService.GetIngredientByIdAsync(TestIngredient1.Id, null, _convertFunc);

        Assert.NotNull(result);
        Assert.Equal(TestIngredient1.Id, result.Id);
        Assert.Equal(TestIngredient1.Name, result.Name);
    }

    [Fact]
    public async Task GetIngredientByIdAsync_NonExistingIngredient_ThrowsNotFoundException()
    {
        _mockIngredientRepository.Setup(r => r.GetByIdAsync(
            It.IsAny<ISpecification<Ingredient>>(),
            TestIngredient1.Id))
            .ReturnsAsync((Ingredient)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _ingredientService.GetIngredientByIdAsync(TestIngredient1.Id, null, _convertFunc));
    }

    #endregion

    #region GetIngredientsAsync Tests

    [Fact]
    public async Task GetIngredientsAsync_ReturnsCorrectPaginatedResult()
    {
        var orderedIngredients = _testIngredients.OrderBy(i => i.Name).ToList();
        var spec = new Mock<ISpecification<Ingredient>>().Object;

        _mockIngredientRepository.Setup(r => r.GetAllAsync(spec))
            .ReturnsAsync(orderedIngredients);
        _mockIngredientRepository.Setup(r => r.CountAsync(spec))
            .ReturnsAsync(2);

        var result = await _ingredientService.GetIngredientsAsync(spec, _convertFunc);

        Assert.NotNull(result);
        Assert.Equal(_testIngredients.Count, result.Data.Count);
        Assert.Equal(TestIngredient2.Name, result.Data[0].Name);
        Assert.Equal(TestIngredient1.Name, result.Data[1].Name);
    }

    [Fact]
    public async Task GetIngredientsAsync_EmptyList_ReturnsEmptyPaginatedResult()
    {
        var spec = new Mock<ISpecification<Ingredient>>().Object;
        _mockIngredientRepository.Setup(r => r.GetAllAsync(spec))
            .ReturnsAsync(new List<Ingredient>());
        _mockIngredientRepository.Setup(r => r.CountAsync(spec))
            .ReturnsAsync(0);

        var result = await _ingredientService.GetIngredientsAsync(spec, _convertFunc);

        Assert.NotNull(result);
        Assert.Empty(result.Data);
    }

    #endregion

    #region GetIngredientsNotPaged Tests

    [Fact]
    public async Task GetIngredientsNotPaged_ReturnsApprovedIngredientsSortedByName()
    {
        var orderedIngredients = _testIngredients.OrderBy(i => i.Name).ToList();
        _mockIngredientRepository.Setup(r => r.GetAllAsync(null))
            .ReturnsAsync(orderedIngredients);

        var result = await _ingredientService.GetIngredientsNotPaged();

        Assert.NotNull(result);
        Assert.Equal(_testIngredients.Count, result.Count);
        Assert.Equal(TestIngredient2.Name, result[0].Name);
        Assert.Equal(TestIngredient1.Name, result[1].Name);
    }

    #endregion

    #region SuggestIngredient Tests

    [Fact]
    public async Task SuggestIngredient_AddsIngredientAndSaves()
    {
        var suggestionDto = new SuggestIngredientDto { Name = "New Ingredient" };

        _mockIngredientRepository.Setup(r => r.AddAsync(TestIngredient1))
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.CompleteAsync());
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        await _ingredientService.SuggestIngredient(suggestionDto);

        _mockIngredientRepository.Verify(r => r.AddAsync(It.IsAny<Ingredient>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    #endregion

    #region CreateIngredientAsync Tests

    [Fact]
    public async Task CreateIngredientAsync_AddsIngredientAndReturnsDto()
    {
        var ingredientDto = new FormIngredientDto
        {
            Name = "Salt",
            IsAllergen = true,
        };

        _mockIngredientRepository.Setup(r => r.AddAsync(TestIngredient1))
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        var result = await _ingredientService.CreateIngredientAsync(ingredientDto);

        Assert.NotNull(result);
        _mockIngredientRepository.Verify(r => r.AddAsync(It.IsAny<Ingredient>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    #endregion

    #region UpdateIngredientAsync Tests

    [Fact]
    public async Task UpdateIngredientAsync_ExistingIngredient_UpdatesSuccessfully()
    {
        var updateDto = new EditFormIngredientDto { Id = TestIngredient1.Id, Name = "New Name" };

        _mockIngredientRepository.Setup(r => r.GetByIdAsync(null, TestIngredient1.Id))
            .ReturnsAsync(TestIngredient1);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        await _ingredientService.UpdateIngredientAsync(updateDto, TestIngredient1.Id);

        _mockIngredientRepository.Verify(r => r.Update(TestIngredient1), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateIngredientAsync_NonExistingIngredient_ThrowsNotFoundException()
    {
        var updateDto = new EditFormIngredientDto { Id = TestIngredient1.Id, Name = "New Name" };

        _mockIngredientRepository.Setup(r => r.GetByIdAsync(null, TestIngredient1.Id))
            .ReturnsAsync((Ingredient)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _ingredientService.UpdateIngredientAsync(updateDto, TestIngredient1.Id));
    }

    [Fact]
    public async Task UpdateIngredientAsync_IdMismatch_ThrowsValidationException()
    {
        //todo check why the ingredient gets whiped out in the service
        var updateDto = new EditFormIngredientDto { Id = TestIngredient1.Id, Name = "New Name" };

        _mockIngredientRepository.Setup(r => r.GetByIdAsync(null, TestIngredient1.Id))
            .ReturnsAsync(TestIngredient1);

        await Assert.ThrowsAsync<ValidationException>(() =>
            _ingredientService.UpdateIngredientAsync(updateDto, TestIngredient2.Id));
    }

    #endregion

    #region DeleteIngredientAsync Tests

    [Fact]
    public async Task DeleteIngredientAsync_ExistingIngredient_DeletesSuccessfully()
    {
        _mockIngredientRepository.Setup(r => r.GetByIdAsync(null, TestIngredient1.Id))
            .ReturnsAsync(TestIngredient1);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        await _ingredientService.DeleteIngredientAsync(TestIngredient1.Id);

        _mockIngredientRepository.Verify(r => r.Delete(TestIngredient1), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteIngredientAsync_NonExistingIngredient_ThrowsNotFoundException()
    {
        _mockIngredientRepository.Setup(r => r.GetByIdAsync(null, TestIngredient1.Id))
            .ReturnsAsync((Ingredient)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _ingredientService.DeleteIngredientAsync(TestIngredient1.Id));
    }

    #endregion

}

