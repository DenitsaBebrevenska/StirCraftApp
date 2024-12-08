using StirCraftApp.Application.DTOs.CommentDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICommentService
{
    Task AddCommentAsync(string userId, int recipeId, CommentFormDto commentFormDto);

    Task EditCommentAsync(string userId, int commentId, EditFormCommentDto commentFormDto);

    Task DeleteCommentAsync(string userId, int commentId);

}
