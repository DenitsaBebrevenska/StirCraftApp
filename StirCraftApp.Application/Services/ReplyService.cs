using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CommentSpec;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Implements the IReplyService interface and uses the Unit of Work pattern for data access.
/// Service for handling replies to comments.
/// </summary>
public class ReplyService(IUnitOfWork unit) : IReplyService
{
    /// <summary>
    /// Adds a reply to a comment.
    /// Validates the existence of recipe, if not throws NotFoundException.
    /// Validates the existence of the comment both in the repository and in the recipe`s comments, if not throws NotFoundException.
    /// </summary>
    /// <param name="recipeId">The ID of the recipe associated with the comment.</param>
    /// <param name="commentId">The ID of the comment that is being replied to. </param>
    /// <param name="replyFormDto">The DTO transferring the data for creating a new reply.</param>
    /// <param name="userId">The ID of the user submitting the reply.</param>
    public async Task AddReplyAsync(int recipeId, int commentId, ReplyFormDto replyFormDto, string userId)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(new RecipeIncludedCommentsAndRepliesSpecification(), recipeId);

        if (recipe == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), recipeId));
        }

        var commentExists = await unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (commentExists == null || recipe.Comments.All(c => c.Id != commentId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        var reply = replyFormDto.ToReply(userId, commentId);
        await unit.Repository<Reply>().AddAsync(reply);
        await unit.CompleteAsync();
    }

    /// <summary>
    /// Edits an existing reply to a comment.
    /// Validates the existence of recipe, if not throws NotFoundException.
    /// Validates the existence of the comment both in the repository and in the recipe`s comments, if not throws NotFoundException.
    /// Validates the existence of the reply both in the repository and in the comment`s replies, if not throws NotFoundException.
    /// Validates the ID of the reply and the ID of the DTO that transfers the data to be edited, if the IDs do not match throws ValidationException.
    /// Validates the ownership of the reply, if the user is not the owner throws NotResourceOwnerException.
    /// </summary>
    /// <param name="recipeId">The ID of the recipe associated with the comment.</param>
    /// <param name="commentId">The ID of the comment that associated with the reply. </param>
    /// <param name="replyId">The ID of the reply that is being edited. </param>
    /// <param name="replyEditForm">The DTO transferring the data for editing the reply.</param>
    /// <param name="userId">The ID of the user submitting the editing.</param>
    public async Task EditReplyAsync(int recipeId, int commentId, int replyId, ReplyEditFormDto replyEditForm, string userId)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(new RecipeIncludedCommentsAndRepliesSpecification(), recipeId);

        if (recipe == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), recipeId));
        }

        var comment = await unit.Repository<Comment>().GetByIdAsync(new CommentIncludeRepliesSpecification(), commentId);

        if (comment == null || recipe.Comments.All(c => c.Id != commentId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyEditForm.Id);

        if (reply == null || comment.Replies.All(r => r.Id != replyId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Reply), replyId));
        }

        if (replyId != replyEditForm.Id)
        {
            throw new ValidationException(string.Format(UrlIdMismatch, nameof(Reply)));
        }

        if (reply.UserId != userId)
        {
            throw new NotResourceOwnerException(string.Format(NotOwner, nameof(Reply), replyId));
        }

        reply.Body = replyEditForm.Body;
        reply.UpdatedOn = DateTime.UtcNow;

        unit.Repository<Reply>().Update(reply);
        await unit.CompleteAsync();
    }

    /// <summary>
    /// Deletes an existing reply to a comment.
    /// Validates the existence of recipe, if not throws NotFoundException.
    /// Validates the existence of the comment both in the repository and in the recipe`s comments, if not throws NotFoundException.
    /// Validates the existence of the reply both in the repository and in the comment`s replies, if not throws NotFoundException.
    /// Validates the ownership of the reply, if the user is not the owner throws NotResourceOwnerException.
    /// </summary>
    /// <param name="recipeId">The ID of the recipe associated with the comment.</param>
    /// <param name="commentId">The ID of the comment that is associated with the reply. </param>
    /// <param name="replyId">The ID of the reply that is being deleted. </param>
    /// <param name="userId">The ID of the user submitting the deletion.</param>
    public async Task DeleteReplyAsync(int recipeId, int commentId, int replyId, string userId)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(new RecipeIncludedCommentsAndRepliesSpecification(), recipeId);

        if (recipe == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), recipeId));
        }

        var comment = await unit.Repository<Comment>().GetByIdAsync(new CommentIncludeRepliesSpecification(), commentId);

        if (comment == null || recipe.Comments.All(c => c.Id != commentId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyId);

        if (reply == null || comment.Replies.All(r => r.Id != replyId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Reply), replyId));
        }

        if (reply.UserId != userId)
        {
            throw new NotResourceOwnerException(string.Format(NotOwner, nameof(Reply), replyId));
        }

        unit.Repository<Reply>().Delete(reply);

        await unit.CompleteAsync();
    }

}
