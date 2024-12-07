﻿using StirCraftApp.Application.DTOs.CommentDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICommentService
{
    Task AddCommentAsync(string userId, int recipeId, CommentFormDto commentFormDto);

    Task EditCommentAsync(string userId, EditFormCommentDto commentFormDto);

    Task DeleteCommentAsync(string userId, int commentId);
    public Task<bool> UserIsCommentCreator(string userId, int commentId);

}