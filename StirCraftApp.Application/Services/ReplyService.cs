using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;
public class ReplyService(IUnitOfWork unit) : IReplyService
{
    public async Task AddReplyAsync(string userId, int commentId, ReplyFormDto replyFormDto)
    {
        var commentExists = await unit.Repository<Comment>().GetByIdAsync(null, commentId);

        if (commentExists == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Comment), commentId));
        }

        var reply = replyFormDto.ToReply(userId, commentId);
        await unit.Repository<Reply>().AddAsync(reply);
        await unit.CompleteAsync();
    }

    public async Task EditReplyAsync(string userId, int replyId, ReplyEditFormDto replyEditForm)
    {
        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyEditForm.Id);

        if (reply == null)
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

    public async Task DeleteReplyAsync(string userId, int replyId)
    {
        var reply = await unit.Repository<Reply>().GetByIdAsync(null, replyId);

        if (reply == null)
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
