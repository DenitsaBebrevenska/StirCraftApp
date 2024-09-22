namespace StirCraftApp.Domain.Entities;
public class User : BaseEntity
{
	public required string UserId { get; set; }

	public string? AvatarUrl { get; set; }
}
