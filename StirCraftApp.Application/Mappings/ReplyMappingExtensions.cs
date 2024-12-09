using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

    public static async Task<CommentReplyDto> ToCommentReplyDtoAsync(this Reply reply, UserManager<AppUser> userManager)
    {
        return new CommentReplyDto
        {
            Id = reply.Id,
            Body = reply.Body,
            UserId = reply.UserId,
            UserDisplayName = (await userManager.Users.FirstOrDefaultAsync(u => u.Id == reply.UserId))
                ?.DisplayName ?? "",
            CreatedOn = reply.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
            UpdatedOn = reply.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss")
        };
    }
}
