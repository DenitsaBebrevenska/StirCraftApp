using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;
public class ReplyService(IUnitOfWork unit) : IReplyService
{
    public async Task AddReplyAsync(string userId, int commentId, ReplyFormDto replyFormDto)
    {
        var commentExists = unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (commentExists == null)
        {
            throw new InvalidOperationException("Comment does not exist");
        }

        var reply = replyFormDto.ToReply(userId, commentId);
        await unit.Repository<Reply>().AddAsync(reply);
        await unit.CompleteAsync();
    }

    public async Task EditReplyAsync(string userId, ReplyEditFormDto replyEditForm)
    {
        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyEditForm.Id);

        if (reply == null)
        {
            throw new Exception("Reply not found");
        }

        if (reply.UserId != userId)
        {
            throw new Exception("You are not the creator of this reply");
        }

        reply.Body = replyEditForm.Body;
        reply.UpdatedOn = DateTime.UtcNow;

        unit.Repository<Reply>().Update(reply);
        await unit.CompleteAsync();
    }

    public async Task DeleteReplyAsync(string userId, int replyId)
    {
        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyId);

        if (reply == null)
        {
            throw new Exception("Reply not found");
        }

        if (reply.UserId != userId)
        {
            throw new Exception("You are not the creator of this reply");
        }

        unit.Repository<Reply>().Delete(reply);

        await unit.CompleteAsync();
    }

    public async Task<bool> UserIsReplyCreator(string userId, int replyId)
    {
        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyId);

        if (reply == null)
        {
            throw new Exception("Reply not found");
        }

        return reply.UserId == userId;
    }
}
