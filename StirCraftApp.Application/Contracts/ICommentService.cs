using StirCraftApp.Application.DTOs.CommentDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICommentService
{
    Task AddCommentAsync(int recipeId, CommentFormDto commentFormDto, string userId);

    Task EditCommentAsync(int recipeId, int commentId, EditFormCommentDto commentFormDto, string userId);

    Task DeleteCommentAsync(int recipeId, int commentId, string userId);

}
