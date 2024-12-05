using StirCraftApp.Application.DTOs.ReplyDtos;

namespace StirCraftApp.Application.Contracts;

public interface IReplyService
{
    Task AddReplyAsync(string userId, int id, ReplyFormDto replyFormDto);
    Task EditReplyAsync(string userId, ReplyEditFormDto replyEditForm);
    Task DeleteReplyAsync(string userId, int replyId);
}
