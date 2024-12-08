﻿namespace StirCraftApp.Application.DTOs.UserDtos;
public class UserInfoDto : BaseDto
{
    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? AvatarUrl { get; set; }

    public int? CookId { get; set; }

    public required string UserId { get; set; }

    public string? Role { get; set; }
}
