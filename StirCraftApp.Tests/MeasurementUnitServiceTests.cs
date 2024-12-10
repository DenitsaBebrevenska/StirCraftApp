using Moq;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using Xunit;

namespace StirCraftApp.Tests;
public class MeasurementUnitServiceTests
{
    private readonly Mock<IRepository<MeasurementUnit>> _repositoryMock;
    private readonly MeasurementUnitService _service;
    private const int NonExistentId = 999;
    private const int TestId1 = 1;
    private const string TestUnitName1 = "Unit1";
    private const string TestUnitAbbreviation1 = "U1";
    private const int TestId2 = 2;
    private const string TestUnitName2 = "Unit2";
    private const string TestUnitAbbreviation2 = "U2";
    public MeasurementUnitServiceTests()
    {
        Mock<IUnitOfWork> unitOfWorkMock = new();
        _repositoryMock = new Mock<IRepository<MeasurementUnit>>();
        unitOfWorkMock.Setup(u => u.Repository<MeasurementUnit>()).Returns(_repositoryMock.Object);
        _service = new MeasurementUnitService(unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetUnitById_ShouldReturnMeasurementUnitDto_WhenUnitExists()
    {
        var measurementUnit = new MeasurementUnit
        { Id = TestId1, Name = TestUnitName1, Abbreviation = TestUnitAbbreviation1 };
        _repositoryMock
            .Setup(r => r
                .GetByIdAsync(It.IsAny<ISpecification<MeasurementUnit>>(), TestId1))
                       .ReturnsAsync(measurementUnit);

        var resultDto = await _service.GetUnitById(null, TestId1);

        Assert.NotNull(resultDto);
        Assert.Equal(measurementUnit.Id, resultDto.Id);
        Assert.Equal(measurementUnit.Name, resultDto.Name);
        Assert.Equal(measurementUnit.Abbreviation, resultDto.Abbreviation);
    }

    [Fact]
    public async Task GetUnitById_ShouldThrowNotFoundException_WhenUnitDoesNotExist()
    {
        _repositoryMock
            .Setup(r => r
                .GetByIdAsync(It.IsAny<ISpecification<MeasurementUnit>>(), NonExistentId))
                       .ReturnsAsync((MeasurementUnit)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _service.GetUnitById(null, NonExistentId));
    }

    [Fact]
    public async Task GetUnitsAsync_ShouldReturnListOfMeasurementUnitDtos()
    {
        var measurementUnits = new List<MeasurementUnit>
        {
            new() { Id = TestId1, Name = TestUnitName1, Abbreviation = TestUnitAbbreviation1 },
            new() { Id = TestId2, Name = TestUnitName2, Abbreviation = TestUnitAbbreviation2 }
        };

        _repositoryMock.
            Setup(r => r
                .GetAllAsync(It.IsAny<ISpecification<MeasurementUnit>>()))
                       .ReturnsAsync(measurementUnits);

        var resultDtos = await _service.GetUnitsAsync(null);

        Assert.NotNull(resultDtos);
        Assert.Equal(2, resultDtos.Count);
        Assert.Equal(measurementUnits[0].Id, resultDtos[0].Id);
        Assert.Equal(measurementUnits[1].Id, resultDtos[1].Id);
        Assert.Collection(resultDtos,
            item =>
            {
                Assert.Equal(TestId1, item.Id);
                Assert.Equal(TestUnitName1, item.Name);
                Assert.Equal(TestUnitAbbreviation1, item.Abbreviation);
            },
            item =>
            {
                Assert.Equal(TestId2, item.Id);
                Assert.Equal(TestUnitName2, item.Name);
                Assert.Equal(TestUnitAbbreviation2, item.Abbreviation);
            }
        );
    }

    [Fact]
    public async Task GetUnitsAsync_WithSpecification_ReturnsFilteredMeasurementUnits()
    {
        var mockSpecification = new Mock<ISpecification<MeasurementUnit>>();
        var measurementUnits = new List<MeasurementUnit>
        {
            new() { Id = TestId1, Name = TestUnitName1, Abbreviation = TestUnitAbbreviation1}
        };


        _repositoryMock
            .Setup(x => x
                .GetAllAsync(mockSpecification.Object))
            .ReturnsAsync(measurementUnits);

        var resultDtos = await _service.GetUnitsAsync(mockSpecification.Object);

        Assert.NotNull(resultDtos);
        Assert.Single(resultDtos);
        Assert.Equal(TestId1, resultDtos[0].Id);
        Assert.Equal(TestUnitName1, resultDtos[0].Name);
        Assert.Equal(TestUnitAbbreviation1, resultDtos[0].Abbreviation);
    }

    [Fact]
    public async Task GetUnitById_WithSpecification_PassesSpecificationToRepository()
    {
        var mockSpecification = new Mock<ISpecification<MeasurementUnit>>();
        var measurementUnit = new MeasurementUnit
        {
            Id = TestId1,
            Name = TestUnitName1,
            Abbreviation = TestUnitAbbreviation1
        };

        _repositoryMock
            .Setup(x => x.GetByIdAsync(mockSpecification.Object, TestId1))
            .ReturnsAsync(measurementUnit);

        await _service.GetUnitById(mockSpecification.Object, TestId1);

        _repositoryMock.Verify(
            x => x.GetByIdAsync(mockSpecification.Object, TestId1),
            Times.Once
        );
    }
}
