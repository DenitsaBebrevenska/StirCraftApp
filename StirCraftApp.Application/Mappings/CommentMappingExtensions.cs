using StirCraftApp.Application.DTOs.CommentDtos;
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

}
