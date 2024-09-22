namespace StirCraftApp.Domain.Entities;
public class User : BaseEntity
{
	public string UserId { get; set; }

	public string? AvatarUrl { get; set; }
}
