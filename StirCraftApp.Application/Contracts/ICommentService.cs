using StirCraftApp.Application.DTOs.CommentDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICommentService
{
    Task AddCommentAsync(string userId, int recipeId, CommentFormDto commentFormDto);

    Task EditCommentAsync(string userId, int recipeId, EditFormCommentDto commentFormDto);

    Task DeleteCommentAsync(int commentId);
    public Task<bool> UserIsCommentCreator(string userId, int commentId);

}
