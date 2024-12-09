using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;
public class CommentService(IUnitOfWork unit) : ICommentService
{

    public async Task AddCommentAsync(string userId, int recipeId, CommentFormDto commentFormDto)
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


    public async Task EditCommentAsync(string userId, int commentId, EditFormCommentDto commentFormDto)
    {
        if (commentId != commentFormDto.Id)
        {
            throw new ValidationException(string.Format(UrlIdMismatch, nameof(Comment)));
        }

        var comment = await unit.Repository<Comment>().GetByIdAsync(null, commentFormDto.Id);

        if (comment == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(comment), commentFormDto.Id));
        }

        if (comment.UserId != userId)
        {
            throw new UnauthorizedAccessException(string.Format(NotOwner, nameof(Comment), commentId));
        }

        comment.Title = commentFormDto.Title;
        comment.Body = commentFormDto.Body;
        comment.UpdatedOn = DateTime.UtcNow;

        unit.Repository<Comment>().Update(comment);
        await unit.CompleteAsync();
    }

    public async Task DeleteCommentAsync(string userId, int commentId)
    {
        var comment = await unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (comment == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        if (comment.UserId != userId)
        {
            throw new UnauthorizedAccessException(string.Format(NotOwner, nameof(Comment), commentId));
        }

        unit.Repository<Comment>().Delete(comment);

        await unit.CompleteAsync();
    }

}
