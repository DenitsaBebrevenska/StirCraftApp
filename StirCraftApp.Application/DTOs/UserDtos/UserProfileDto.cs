using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.UserDtos;
public class UserProfileDto : IDto
{
    public required string DisplayName { get; set; }

    public required string Email { get; set; }

    public string? AvatarUrl { get; set; }

    public bool IsCook { get; set; }
}
