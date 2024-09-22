using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data;
public class StirCraftDbContext : IdentityDbContext<IdentityUser>
{
	public DbSet<Category> Categories { get; set; }

	public DbSet<Comment> Comments { get; set; }

	public DbSet<Cook> Cooks { get; set; }

	public DbSet<Ingredient> Ingredients { get; set; }

	public DbSet<MeasurementUnit> MeasurementUnits { get; set; }

	public DbSet<Recipe> Recipes { get; set; }

	public DbSet<RecipeImage> RecipeImages { get; set; }

	public DbSet<RecipeRating> RecipeRatings { get; set; }

	public DbSet<Reply> Replies { get; set; }

	public DbSet<User> ApplicationUsers { get; set; }
	public StirCraftDbContext(DbContextOptions<StirCraftDbContext> options) : base(options)
	{
	}

}