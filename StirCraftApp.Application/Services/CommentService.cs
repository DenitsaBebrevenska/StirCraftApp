using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;
public class CommentService(IUnitOfWork unit) : ICommentService
{
    public async Task AddCommentAsync(string userId, int recipeId, CommentFormDto commentFormDto)
    {
        var comment = commentFormDto.ToComment(userId, recipeId);

        await unit.Repository<Comment>().AddAsync(comment);
        await unit.CompleteAsync();
    }

    public async Task EditCommentAsync(string userId, int recipeId, EditFormCommentDto commentFormDto)
    {
        var comment = await unit.Repository<Comment>().GetByIdAsync(null, commentFormDto.Id);

        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        if (comment.UserId != userId)
        {
            throw new Exception("You are not the creator of this comment");
        }

        comment.Title = commentFormDto.Title;
        comment.Body = commentFormDto.Body;
        comment.UpdatedOn = DateTime.UtcNow;

        unit.Repository<Comment>().Update(comment);
        await unit.CompleteAsync();
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UserIsCommentCreator(string userId, int commentId)
    {
        var comment = await unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        return comment.UserId == userId;
    }
}
