using Moq;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using Xunit;

namespace StirCraftApp.Tests;
public class CommentUnitServiceTests
{
    private readonly Mock<IRepository<Recipe>> _mockRecipeRepository;
    private readonly Mock<IRepository<Comment>> _mockCommentRepository;
    private readonly CommentService _service;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private const string TestUserId = "user123";
    private const string TestUserNotOwnerId = "user777";
    private const int TestRecipeId = 1;
    private const int TestCommentId = 1;
    private const int TestCommentId2 = 2;
    private const string TestCommentTitle = "Test Comment";
    private const string TestCommentBody = "Test Body";
    private const string TestCommentEditedTitle = "Edited Comment";
    private const string TestCommentEditedBody = "Edited Body";
    private const int NonExistentCommentId = 999;

    private static readonly Comment ExistingComment = new Comment
    {
        Id = TestCommentId,
        UserId = TestUserId,
        Title = TestCommentTitle,
        Body = TestCommentBody
    };
    private readonly Recipe _existingRecipe = new Recipe
    {
        Id = 1,
        Name = "Test Recipe",
        PreparationSteps = "Test Steps",
        Comments =
        {
            ExistingComment
        }
    };
    public CommentUnitServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockRecipeRepository = new Mock<IRepository<Recipe>>();
        _mockCommentRepository = new Mock<IRepository<Comment>>();


        _mockUnitOfWork
            .Setup(x => x.Repository<Recipe>())
            .Returns(_mockRecipeRepository.Object);
        _mockUnitOfWork
            .Setup(x => x.Repository<Comment>())
            .Returns(_mockCommentRepository.Object);

        _service = new CommentService(_mockUnitOfWork.Object);
    }

    #region AddCommentAsync Tests
    [Fact]
    public async Task AddCommentAsync_ValidInput_AddsCommentSuccessfully()
    {
        var commentFormDto = new CommentFormDto
        {
            Title = TestCommentTitle,
            Body = TestCommentBody
        };

        _mockRecipeRepository
            .Setup(x => x.ExistsAsync(TestRecipeId))
            .ReturnsAsync(true);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        await _service.AddCommentAsync(TestRecipeId, commentFormDto, TestUserId);


        _mockCommentRepository.Verify(
            x => x.AddAsync(It.Is<Comment>(c =>
                c.UserId == TestUserId &&
                c.RecipeId == TestRecipeId &&
                c.Title == commentFormDto.Title &&
                c.Body == commentFormDto.Body)),
            Times.Once
        );

        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task AddCommentAsync_NonExistentRecipe_ThrowsNotFoundException()
    {

        var commentFormDto = new CommentFormDto
        {
            Title = TestCommentTitle,
            Body = TestCommentBody
        };

        _mockRecipeRepository
            .Setup(x => x.ExistsAsync(NonExistentCommentId))
            .ReturnsAsync(false);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _service.AddCommentAsync(TestRecipeId, commentFormDto, TestUserNotOwnerId));
    }
    #endregion

    #region EditCommentAsync Tests
    [Fact]
    public async Task EditCommentAsync_ValidInput_UpdatesCommentSuccessfully()
    {
        var editFormDto = new EditFormCommentDto
        {
            Id = TestCommentId,
            Title = TestCommentEditedTitle,
            Body = TestCommentEditedBody
        };

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), _existingRecipe.Id))
            .ReturnsAsync(_existingRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, ExistingComment.Id))
            .ReturnsAsync(ExistingComment);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        await _service.EditCommentAsync(TestRecipeId, TestCommentId, editFormDto, TestUserId);


        Assert.Equal(TestCommentEditedTitle, ExistingComment.Title);
        Assert.Equal(TestCommentEditedBody, ExistingComment.Body);
        Assert.NotEqual(DateTime.MinValue, ExistingComment.UpdatedOn);

        _mockCommentRepository.Verify(x => x.Update(ExistingComment), Times.Once);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task EditCommentAsync_IdMismatch_ThrowsValidationException()
    {
        var editFormDto = new EditFormCommentDto
        {
            Id = TestCommentId2,
            Title = TestCommentEditedTitle,
            Body = TestCommentEditedBody
        };

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), _existingRecipe.Id))
            .ReturnsAsync(_existingRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, ExistingComment.Id))
            .ReturnsAsync(ExistingComment);

        await Assert.ThrowsAsync<ValidationException>(() =>
            _service.EditCommentAsync(TestRecipeId, TestCommentId, editFormDto, TestUserId));
    }

    [Fact]
    public async Task EditCommentAsync_NonExistentComment_ThrowsNotFoundException()
    {

        var editFormDto = new EditFormCommentDto
        {
            Id = NonExistentCommentId,
            Title = TestCommentEditedTitle,
            Body = TestCommentEditedBody
        };

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, NonExistentCommentId))
            .ReturnsAsync((Comment)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _service.EditCommentAsync(TestRecipeId, TestCommentId, editFormDto, TestUserId));
    }

    [Fact]
    public async Task EditCommentAsync_DifferentUser_ThrowsUnauthorizedAccessException()
    {
        var editFormDto = new EditFormCommentDto
        {
            Id = TestCommentId,
            Title = TestCommentEditedTitle,
            Body = TestCommentEditedBody
        };



        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), _existingRecipe.Id))
            .ReturnsAsync(_existingRecipe);


        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, TestCommentId))
            .ReturnsAsync(ExistingComment);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _service.EditCommentAsync(TestRecipeId, TestCommentId, editFormDto, TestUserNotOwnerId));
    }
    #endregion

    #region DeleteCommentAsync Tests
    [Fact]
    public async Task DeleteCommentAsync_ValidInput_DeletesCommentSuccessfully()
    {

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), _existingRecipe.Id))
            .ReturnsAsync(_existingRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, TestCommentId))
            .ReturnsAsync(ExistingComment);
        _mockUnitOfWork.Setup(u => u.CompleteAsync())
            .ReturnsAsync(true);

        await _service.DeleteCommentAsync(TestRecipeId, TestCommentId, TestUserId);

        _mockCommentRepository.Verify(x => x.Delete(ExistingComment), Times.Once);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteCommentAsync_NonExistentComment_ThrowsNotFoundException()
    {
        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, NonExistentCommentId))
            .ReturnsAsync((Comment)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _service.DeleteCommentAsync(TestRecipeId, NonExistentCommentId, TestUserId));
    }

    [Fact]
    public async Task DeleteCommentAsync_DifferentUser_ThrowsUnauthorizedAccessException()
    {

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), _existingRecipe.Id))
            .ReturnsAsync(_existingRecipe);
        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<ISpecification<Comment>>(), TestCommentId))
            .ReturnsAsync(ExistingComment);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _service.DeleteCommentAsync(TestRecipeId, TestCommentId, TestUserNotOwnerId));
    }
    #endregion
}

