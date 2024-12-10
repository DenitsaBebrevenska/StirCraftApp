using Moq;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using Xunit;

namespace StirCraftApp.Tests;
public class ReplyUnitServiceTests
{
    private readonly Mock<IRepository<Reply>> _replyRepoMock;
    private readonly Mock<IRepository<Comment>> _commentRepoMock;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly ReplyService _service;

    private readonly Comment _testComment = new Comment
    {
        Id = 1,
        UserId = "user123",
        RecipeId = 42,
        Title = "Test title",
        Body = "Test body",
    };

    private readonly Reply _testReply = new Reply
    {
        Id = 1,
        UserId = "user777",
        CommentId = 1,
        Body = "Test reply body",
    };

    public ReplyUnitServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _commentRepoMock = new Mock<IRepository<Comment>>();
        _replyRepoMock = new Mock<IRepository<Reply>>();

        _mockUnitOfWork.Setup(u => u.Repository<Comment>()).Returns(_commentRepoMock.Object);
        _mockUnitOfWork.Setup(u => u.Repository<Reply>()).Returns(_replyRepoMock.Object);

        _service = new ReplyService(_mockUnitOfWork.Object);
    }


    #region AddReplytAsync Tests

    [Fact]
    public async Task AddReplyAsync_ValidData_AddsReplyAndSavesChanges()
    {
        var replyFormDto = new ReplyFormDto { Body = "Test reply" };

        _commentRepoMock.Setup(r => r.GetByIdAsync(null, _testComment.Id)).ReturnsAsync(_testComment);

        _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

        await _service.AddReplyAsync(_testComment.UserId, _testComment.Id, replyFormDto);

        _replyRepoMock.Verify(r => r.AddAsync(It.IsAny<Reply>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task AddReplyAsync_CommentNotFound_ThrowsNotFoundException()
    {
        var replyFormDto = new ReplyFormDto
        {
            Body = "Test reply"
        };

        _commentRepoMock.Setup(r => r.GetByIdAsync(null, _testComment.Id)).ReturnsAsync((Comment)null);

        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddReplyAsync(_testComment.UserId, _testComment.Id, replyFormDto));
    }
    #endregion

    #region EditReplyAsync Tests

    [Fact]
    public async Task EditReplyAsync_ValidData_UpdatesReplyAndSavesChanges()
    {
        var editFormDto = new ReplyEditFormDto { Id = _testReply.Id, Body = "Updated body" };

        _replyRepoMock.Setup(r => r.GetByIdAsync(null, _testReply.Id)).ReturnsAsync(_testReply);
        _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

        await _service.EditReplyAsync(_testReply.UserId, _testReply.Id, editFormDto);

        Assert.Equal("Updated body", _testReply.Body);
        _replyRepoMock.Verify(r => r.Update(_testReply), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task EditReplyAsync_ReplyNotFound_ThrowsNotFoundException()
    {
        var editFormDto = new ReplyEditFormDto { Id = _testReply.Id, Body = "Updated body" };
        _replyRepoMock.Setup(r => r.GetByIdAsync(null, _testReply.Id)).ReturnsAsync((Reply)null);

        await Assert.ThrowsAsync<NotFoundException>(() => _service.EditReplyAsync(
            _testReply.UserId, _testReply.Id, editFormDto));
    }

    #endregion

    #region DeleteReplyAsync Tests
    [Fact]
    public async Task DeleteReplyAsync_ValidData_DeletesReplyAndSavesChanges()
    {
        _replyRepoMock.Setup(r => r.GetByIdAsync(null, _testReply.Id)).ReturnsAsync(_testReply);
        _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

        await _service.DeleteReplyAsync(_testReply.UserId, _testReply.Id);

        _replyRepoMock.Verify(r => r.Delete(_testReply), Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteReplyAsync_ReplyNotFound_ThrowsNotFoundException()
    {
        _replyRepoMock.Setup(r => r.GetByIdAsync(null, _testReply.Id)).ReturnsAsync((Reply)null);

        await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteReplyAsync(_testReply.UserId, _testReply.Id));
    }

    [Fact]
    public async Task DeleteReplyAsync_NotOwner_ThrowsNotResourceOwnerException()
    {
        _replyRepoMock.Setup(r => r.GetByIdAsync(null, _testReply.Id)).ReturnsAsync(_testReply);

        await Assert.ThrowsAsync<NotResourceOwnerException>(() => _service.DeleteReplyAsync(_testComment.UserId, _testReply.Id));
    }
    #endregion
}
