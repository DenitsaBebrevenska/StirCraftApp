﻿using StirCraftApp.Application.DTOs.UserDtos;

namespace StirCraftApp.Application.Contracts;
public interface IUserService
{
    Task<UserInfoDto> GetUserProfileAsync(string userId);

    Task UpdateAvatarAsync(string userId, AvatarUpdateDto avatarDto);
}
