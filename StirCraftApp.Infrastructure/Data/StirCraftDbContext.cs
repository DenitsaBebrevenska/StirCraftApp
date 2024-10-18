using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.JoinedTables;
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

	public DbSet<CookingRank> CookingRanks { get; set; } = null!;

	public DbSet<ShoppingList> ShoppingLists { get; set; } = null!;

	public DbSet<UserFavoriteRecipe> UsersFavoriteRecipes { get; set; } = null!;

	public DbSet<CategoryRecipe> CategoriesRecipes { get; set; } = null!;

	public DbSet<ShoppingListRecipeIngredient> ShoppingListsRecipeIngredients { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Cook>()
			.HasOne<AppUser>()
			.WithOne()
			.HasForeignKey<Cook>(c => c.UserId);

		builder.Entity<Comment>()
			.HasOne<AppUser>()
			.WithMany(u => u.Comments)
			.HasForeignKey(c => c.UserId);

		builder.Entity<Reply>()
			.HasOne<AppUser>()
			.WithMany(r => r.Replies)
			.HasForeignKey(r => r.UserId);

		builder.Entity<ShoppingList>()
			.HasOne<AppUser>()
			.WithMany(u => u.ShoppingLists)
			.HasForeignKey(s => s.UserId);

		builder.Entity<RecipeRating>()
			.HasOne<AppUser>()
			.WithMany(u => u.RecipesRatings)
			.HasForeignKey(rr => rr.UserId);

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
				fk.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}

		builder.Entity<UserFavoriteRecipe>()
			.HasQueryFilter(ufr => !ufr.AppUser.IsDeleted && !ufr.Recipe.IsDeleted);

		builder.Entity<CategoryRecipe>()
			.HasQueryFilter(cr => !cr.Category.IsDeleted && !cr.Recipe.IsDeleted);

		builder.Entity<ShoppingListRecipeIngredient>()
			.HasQueryFilter(slri => !slri.ShoppingList.IsDeleted && !slri.RecipeIngredient.IsDeleted);

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