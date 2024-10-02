﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
		builder.Entity<Cook>()
			.HasOne<AppUser>()
			.WithOne()
			.HasForeignKey<Cook>(c => c.UserId);

		builder.Entity<Comment>()
			.HasOne<AppUser>()
			.WithOne()
			.HasForeignKey<Comment>(c => c.UserId);


		builder.Entity<RecipeRating>()
			.HasOne<Recipe>()
			.WithMany(r => r.RecipeRatings)
			.HasForeignKey(rr => rr.RecipeId)
			.OnDelete(DeleteBehavior.ClientNoAction);

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
			.WithOne()
			.HasForeignKey<RecipeRating>(rr => rr.UserId);

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
		}

		base.OnModelCreating(builder);
	}

	private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : class, ISoftDeletable
	{
		builder.Entity<TEntity>()
			.HasQueryFilter(e => !e.IsDeleted);
	}

}