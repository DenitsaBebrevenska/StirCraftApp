using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StirCraftApp.Infrastructure.Persistence;
public class StirCraftDbContext(DbContextOptions<StirCraftDbContext> options)
	: IdentityDbContext<ApplicationUser>(options);
