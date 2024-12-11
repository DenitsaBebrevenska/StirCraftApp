using Moq;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CommentSpec;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using Xunit;

namespace StirCraftApp.Tests;
public class ReplyUnitServiceTests
{
    private readonly Mock<IRepository<Reply>> _mockReplyRepository;
    private readonly Mock<IRepository<Comment>> _mockCommentRepository;
    private readonly Mock<IRepository<Recipe>> _mockRecipeRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly ReplyService _replyService;

    private const string TestUserNotOwner = "userNotOwner";

    private static readonly Reply TestReply = new Reply
    {
        Id = 1,
        UserId = "user777",
        CommentId = 1,
        Body = "Test reply body",
    };

    private static readonly Comment TestComment = new Comment
    {
        Id = 1,
        UserId = "user123",
        RecipeId = 42,
        Title = "Test title",
        Body = "Test body",
        Replies = new List<Reply>
        {
            TestReply
        }
    };


    private readonly Recipe _testRecipe = new Recipe
    {
        Id = 42,
        Name = "Test Recipe",
        PreparationSteps = "Test description",
        Comments = new List<Comment>
        {
            TestComment
        }
    };

    public ReplyUnitServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockRecipeRepository = new Mock<IRepository<Recipe>>();
        _mockCommentRepository = new Mock<IRepository<Comment>>();
        _mockReplyRepository = new Mock<IRepository<Reply>>();

        _mockUnitOfWork.Setup(u => u.Repository<Recipe>()).Returns(_mockRecipeRepository.Object);
        _mockUnitOfWork.Setup(u => u.Repository<Comment>()).Returns(_mockCommentRepository.Object);
        _mockUnitOfWork.Setup(u => u.Repository<Reply>()).Returns(_mockReplyRepository.Object);

        _replyService = new ReplyService(_mockUnitOfWork.Object);
    }


    #region AddReplytAsync Tests

    [Fact]
    public async Task AddReplyAsync_ValidData_ShouldAddReply()
    {
        var replyFormDto = new ReplyFormDto { Body = "Test Reply" };

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync(_testRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, TestComment.Id))
            .ReturnsAsync(TestComment);

        _mockReplyRepository
            .Setup(x => x.AddAsync(It.IsAny<Reply>()))
            .Returns(Task.CompletedTask);

        await _replyService.AddReplyAsync(_testRecipe.Id, TestComment.Id, replyFormDto, TestReply.UserId);

        _mockReplyRepository.Verify(x => x.AddAsync(It.Is<Reply>(
            r => r.Body == replyFormDto.Body &&
            r.UserId == TestReply.UserId &&
            r.CommentId == TestComment.Id)), Times.Once);

        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }


    [Fact]
    public async Task AddReplyAsync_RecipeNotFound_ThrowsNotFoundException()
    {
        var replyFormDto = new ReplyFormDto { Body = "Test Reply" };

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync((Recipe)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _replyService.AddReplyAsync(_testRecipe.Id, TestComment.Id, replyFormDto, TestReply.UserId));
    }

    [Fact]
    public async Task AddReplyAsync_CommentNotFound_ThrowsNotFoundException()
    {
        var replyFormDto = new ReplyFormDto { Body = "Test Reply" };

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync(_testRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(null, TestComment.Id))
            .ReturnsAsync((Comment)null);

        await Assert.ThrowsAsync<NotFoundException>(() =>
            _replyService.AddReplyAsync(_testRecipe.Id, TestComment.Id, replyFormDto, TestReply.UserId));
    }
    #endregion

    #region EditReplyAsync Tests
    [Fact]
    public async Task EditReplyAsync_ValidData_ShouldUpdateReply()
    {
        var replyEditForm = new ReplyEditFormDto
        {
            Id = TestReply.Id,
            Body = "Updated Reply"
        };

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync(_testRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<CommentIncludeRepliesSpecification>(), TestComment.Id))
            .ReturnsAsync(TestComment);

        _mockReplyRepository
            .Setup(x => x.GetByIdAsync(null, TestReply.Id))
            .ReturnsAsync(TestReply);


        await _replyService.EditReplyAsync(_testRecipe.Id, TestComment.Id, TestReply.Id, replyEditForm, TestReply.UserId);

        _mockReplyRepository.Verify(x => x.Update(It.Is<Reply>(
            r => r.Body == replyEditForm.Body &&
            r.UpdatedOn != null)), Times.Once);

        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }


    [Fact]
    public async Task EditReplyAsync_NotOwner_ThrowsNotResourceOwnerException()
    {

        var replyEditForm = new ReplyEditFormDto
        {
            Id = TestReply.Id,
            Body = "Updated Reply"
        };


        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync(_testRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<CommentIncludeRepliesSpecification>(), TestComment.Id))
            .ReturnsAsync(TestComment);

        _mockReplyRepository
            .Setup(x => x.GetByIdAsync(null, TestReply.Id))
            .ReturnsAsync(TestReply);


        await Assert.ThrowsAsync<NotResourceOwnerException>(() =>
            _replyService.EditReplyAsync(_testRecipe.Id, TestComment.Id, TestReply.Id, replyEditForm, TestUserNotOwner));
    }
    #endregion

    #region DeleteReplyAsync Tests
    [Fact]
    public async Task DeleteReplyAsync_ValidData_ShouldDeleteReply()
    {

        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync(_testRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<CommentIncludeRepliesSpecification>(), TestComment.Id))
            .ReturnsAsync(TestComment);

        _mockReplyRepository
            .Setup(x => x.GetByIdAsync(null, TestReply.Id))
            .ReturnsAsync(TestReply);

        await _replyService.DeleteReplyAsync(_testRecipe.Id, TestComment.Id, TestReply.Id, TestReply.UserId);

        _mockReplyRepository.Verify(x => x.Delete(It.Is<Reply>(r => r.Id == TestReply.Id)), Times.Once);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteReplyAsync_NotOwner_ThrowsNotResourceOwnerException()
    {
        _mockRecipeRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<RecipeIncludedCommentsAndRepliesSpecification>(), _testRecipe.Id))
            .ReturnsAsync(_testRecipe);

        _mockCommentRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<CommentIncludeRepliesSpecification>(), TestComment.Id))
            .ReturnsAsync(TestComment);

        _mockReplyRepository
            .Setup(x => x.GetByIdAsync(null, TestReply.Id))
            .ReturnsAsync(TestReply);

        await Assert.ThrowsAsync<NotResourceOwnerException>(() =>
            _replyService.DeleteReplyAsync(_testRecipe.Id, TestComment.Id, TestReply.Id, TestUserNotOwner));
    }
    #endregion
}

