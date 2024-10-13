using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;
using System.Reflection;

namespace StirCraftApp.Infrastructure.Data;
public class StirCraftDbContext(DbContextOptions<StirCraftDbContext> options) : IdentityDbContext<AppUser>(options)
{
	public DbSet<Category> Categories { get; set; } = null!;

	public DbSet<Comment> Comments { get; set; } = null!;

	public DbSet<Cook> Cooks { get; set; } = null!;

	public DbSet<Ingredient> Ingredients { get; set; } = null!;

	public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;

	public DbSet<MeasurementUnit> MeasurementUnits { get; set; } = null!;

	public DbSet<Recipe> Recipes { get; set; } = null!;

	public DbSet<RecipeImage> RecipeImages { get; set; } = null!;

	public DbSet<RecipeRating> RecipeRatings { get; set; } = null!;

	public DbSet<Reply> Replies { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Recipe>()
			.HasMany<AppUser>()
			.WithMany(u => u.FavoriteRecipes);

		builder.Entity<Cook>()
			.HasOne<AppUser>()
			.WithOne()
			.HasForeignKey<Cook>(c => c.UserId);

		builder.Entity<Cook>()
			.HasOne<CookingRank>()
			.WithMany(r => r.CooksWithThatRank)
			.HasForeignKey(c => c.CookingRankId);

		builder.Entity<Comment>()
			.HasOne<AppUser>()
			.WithOne()
			.HasForeignKey<Comment>(c => c.UserId);

		builder.Entity<Reply>()
			.HasOne<AppUser>()
			.WithOne()
			.HasForeignKey<Reply>(r => r.UserId);

		builder.Entity<ShoppingList>()
			.HasOne<AppUser>()
			.WithMany(u => u.ShoppingLists)
			.HasForeignKey(s => s.UserId);

		builder.Entity<RecipeRating>()
			.HasOne<AppUser>()
			.WithMany(u => u.RecipesRatings)
			.HasForeignKey(rr => rr.UserId);

		builder.Entity<RecipeIngredient>()
			.HasOne<MeasurementUnit>()
			.WithMany(m => m.RecipeIngredients)
			.HasForeignKey(ri => ri.MeasurementUnitId);

		builder.Entity<AppUser>()
			.HasIndex(u => u.DisplayName)
			.IsUnique();

		var allEntityTypes = builder
			.Model
			.GetEntityTypes();

		foreach (var entityType in allEntityTypes)
		{
			foreach (var fk in entityType.GetForeignKeys())
			{
				fk.DeleteBehavior = DeleteBehavior.ClientNoAction;
			}
		}

		var softDeletables = allEntityTypes
			.Where(et => typeof(ISoftDeletable).IsAssignableFrom(et.ClrType));

		foreach (var entityType in softDeletables)
		{
			var method = typeof(StirCraftDbContext)
				.GetMethod(nameof(ApplySoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)?
				.MakeGenericMethod(entityType.ClrType);

			method?.Invoke(null, new object[] { builder });

			ApplyFilteredIndex(builder, entityType.ClrType);
		}

		base.OnModelCreating(builder);
	}

	private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : class
	{
		builder.Entity<TEntity>()
			.HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
	}

	private static void ApplyFilteredIndex(ModelBuilder builder, Type entityType)
	{
		var entityBuilder = builder.Entity(entityType);

		entityBuilder.HasIndex(nameof(ISoftDeletable.IsDeleted))
			.HasFilter($"[{nameof(ISoftDeletable.IsDeleted)}] = 0");
	}

}