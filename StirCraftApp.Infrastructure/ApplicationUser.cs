using Microsoft.AspNetCore.Identity;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure;
public class ApplicationUser : IdentityUser, IApplicationUser
{
	public string? AvatarUrl { get; set; }
}
