using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class ReplyMappingExtensions
{
    public static Reply ToReply(this ReplyFormDto replyFormDto, string userId, int commentId)
    {
        return new Reply
        {
            UserId = userId,
            CommentId = commentId,
            Body = replyFormDto.Body,
            CreatedOn = DateTime.UtcNow
        };
    }
}
