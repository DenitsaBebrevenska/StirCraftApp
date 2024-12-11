using StirCraftApp.Application.DTOs.ReplyDtos;

namespace StirCraftApp.Application.Contracts;

public interface IReplyService
{
    Task AddReplyAsync(int recipeId, int commentId, ReplyFormDto replyFormDto, string userId);
    Task EditReplyAsync(int recipeId, int commentId, int replyId, ReplyEditFormDto replyEditForm, string userId);
    Task DeleteReplyAsync(int recipeId, int commentId, int replyId, string userId);
}
