namespace StirCraftApp.Application.DTOs.UserDtos;

/// <summary>
/// Data transfer object for user information
/// </summary>
public class UserInfoDto : BaseDto
{
    /// <summary>
    /// The Display name of the user if any
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// The email of the user if any
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The url leading to the avatar image of the user if any
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// The identifier of the cook if the user is cook at all
    /// </summary>
    public int? CookId { get; set; }

    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// The role of the user
    /// </summary>
    public string? Role { get; set; }
}
