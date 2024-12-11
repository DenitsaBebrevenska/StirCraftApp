using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Provides methods for adding, editing, and deleting comments on recipes.
/// Implements the ICommentService interface and uses the Unit of Work pattern for data operations.
/// </summary>
public class CommentService(IUnitOfWork unit) : ICommentService
{
    /// <summary>
    /// Adds a new comment to a recipe.
    /// Validates that the recipe exists before adding the comment.
    /// If the recipe does not exist, a NotFoundException is thrown.
    /// </summary>
    /// <param name="userId">The ID of the user adding the comment.</param>
    /// <param name="recipeId">The ID of the recipe the comment is associated with.</param>
    /// <param name="commentFormDto">The data transfer object containing the comment details.</param>
    public async Task AddCommentAsync(int recipeId, CommentFormDto commentFormDto, string userId)
    {
        var recipeExists = await unit.Repository<Recipe>()
            .ExistsAsync(recipeId);

        if (recipeExists == false)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), recipeId));
        }

        var comment = commentFormDto.ToComment(userId, recipeId);

        await unit.Repository<Comment>().AddAsync(comment);
        await unit.CompleteAsync();
    }

    /// <summary>
    /// Edits an existing comment if the user is the owner of the comment.
    /// Validates that the recipe exists before editing the comment. If the recipe does not exist, a NotFoundException is thrown.
    /// Validates that the comment exists before editing it. If the comment does not exist, a NotFoundException is thrown.
    /// Validates that the user is the owner of the comment. If the user is not the owner, an UnauthorizedAccessException is thrown.
    /// Validates that the comment ID in the URL matches the comment ID in the form. If the IDs do not match, a ValidationException is thrown.
    /// </summary>
    /// <param name="recipeId">The ID of the recipe the comment is associated with.</param>
    /// <param name="userId">The ID of the user editing the comment.</param>
    /// <param name="commentId">The ID of the comment being edited.</param>
    /// <param name="commentFormDto">The data transfer object containing the new comment details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task EditCommentAsync(int recipeId, int commentId, EditFormCommentDto commentFormDto, string userId)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(new RecipeIncludedCommentsAndRepliesSpecification(), recipeId);

        if (recipe == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), recipeId));
        }

        if (commentId != commentFormDto.Id)
        {
            throw new ValidationException(string.Format(UrlIdMismatch, nameof(Comment)));
        }

        var commentFound = await unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (commentFound == null || recipe.Comments.All(c => c.Id != commentId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        if (commentFound!.UserId != userId)
        {
            throw new UnauthorizedAccessException(string.Format(NotOwner, nameof(Comment), commentId));
        }

        commentFound.Title = commentFormDto.Title;
        commentFound.Body = commentFormDto.Body;
        commentFound.UpdatedOn = DateTime.UtcNow;

        unit.Repository<Comment>().Update(commentFound);
        await unit.CompleteAsync();
    }

    /// <summary>
    /// Deletes a comment if the user is the owner of the comment.
    /// Validates that the recipe exists before deleting the comment. If the recipe does not exist, a NotFoundException is thrown.
    /// Validates that the comment exists before deleting it. If the comment does not exist, a NotFoundException is thrown.
    /// Validates that the user is the owner of the comment. If the user is not the owner, an UnauthorizedAccessException is thrown.
    /// </summary>
    /// <param name="recipeId">The ID of the recipe the comment is associated with.</param>
    /// <param name="userId">The ID of the user deleting the comment.</param>
    /// <param name="commentId">The ID of the comment to be deleted.</param>
    public async Task DeleteCommentAsync(int recipeId, int commentId, string userId)
    {
        var recipe = await unit.Repository<Recipe>()
            .GetByIdAsync(new RecipeIncludedCommentsAndRepliesSpecification(), recipeId);

        if (recipe == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), recipeId));
        }

        var commentFound = await unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (commentFound == null || recipe.Comments.All(c => c.Id != commentId))
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        if (commentFound!.UserId != userId)
        {
            throw new UnauthorizedAccessException(string.Format(NotOwner, nameof(Comment), commentId));
        }

        unit.Repository<Comment>().Delete(commentFound);

        await unit.CompleteAsync();
    }

}
