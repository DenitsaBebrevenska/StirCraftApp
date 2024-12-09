using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.ReplyDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class CommentMappingExtensions
{
    public static Comment ToComment(this CommentFormDto commentFormDto, string userId, int recipeId)
    {
        return new Comment
        {
            UserId = userId,
            RecipeId = recipeId,
            Title = commentFormDto.Title,
            Body = commentFormDto.Body,
            CreatedOn = DateTime.UtcNow
        };
    }


    public static async Task<RecipeCommentDto> ToRecipeCommentDtoAsync(this Comment comment, UserManager<AppUser> userManager)
    {
        return new RecipeCommentDto
        {
            Id = comment.Id,
            Body = comment.Body,
            Title = comment.Title,
            UserId = comment.UserId,
            UserDisplayName =
                (await userManager.Users.FirstOrDefaultAsync(u => u.Id == comment.UserId))?.DisplayName ?? "",
            CreatedOn = comment.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss"),
            UpdatedOn = comment.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss"),
            Replies = new List<CommentReplyDto>()
        };
    }

}
