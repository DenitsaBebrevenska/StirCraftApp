using System.ComponentModel.DataAnnotations;

namespace StirCraftApp.Application.DTOs.UserDtos;
public class UserRegisterDto
{
    [Required]
    public string DisplayName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
