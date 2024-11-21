﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Infrastructure.Data.EntityConfigurations;
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
        //Defining all AppUser connections since the Domain is kept without references
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


        //joined tables
        builder.Entity<CategoryRecipe>()
            .HasKey(cr => new { cr.RecipeId, cr.CategoryId });

        builder.Entity<CategoryRecipe>()
            .HasOne(cr => cr.Recipe)
            .WithMany(r => r.CategoryRecipes)
            .HasForeignKey(cr => cr.RecipeId);

        builder.Entity<CategoryRecipe>()
            .HasOne(cr => cr.Category)
            .WithMany(c => c.CategoryRecipes)
            .HasForeignKey(cr => cr.CategoryId);

        builder.Entity<ShoppingListRecipeIngredient>()
            .HasKey(slri => new { slri.RecipeIngredientId, slri.ShoppingListId });

        builder.Entity<ShoppingListRecipeIngredient>()
            .HasOne(slri => slri.RecipeIngredient)
            .WithMany(ri => ri.ShoppingListRecipeIngredients)
            .HasForeignKey(slri => slri.RecipeIngredientId);

        builder.Entity<ShoppingListRecipeIngredient>()
            .HasOne(slri => slri.ShoppingList)
            .WithMany(sl => sl.ShoppingListRecipeIngredients)
            .HasForeignKey(slri => slri.ShoppingListId);

        builder.Entity<UserFavoriteRecipe>()
            .HasKey(ufr => new { ufr.UserId, ufr.RecipeId });

        builder.Entity<UserFavoriteRecipe>()
            .HasOne<AppUser>()
            .WithMany(u => u.FavoriteRecipes)
            .HasForeignKey(ufr => ufr.UserId);

        builder.Entity<UserFavoriteRecipe>()
            .HasOne(ufr => ufr.Recipe)
            .WithMany(r => r.UserFavoriteRecipes)
            .HasForeignKey(ufr => ufr.RecipeId);

        //Adding unique display name
        builder.Entity<AppUser>()
            .HasIndex(u => u.DisplayName)
            .IsUnique();

        var allEntityTypes = builder
            .Model
            .GetEntityTypes();

        //Delete behavior no action for all FK
        foreach (var entityType in allEntityTypes)
        {
            foreach (var fk in entityType.GetForeignKeys())
            {
                fk.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        //Joined tables explicit filters so that I don`t get unexpected results
        builder.Entity<UserFavoriteRecipe>()
            .HasQueryFilter(ufr => !ufr.Recipe.IsDeleted);

        builder.Entity<CategoryRecipe>()
            .HasQueryFilter(cr => !cr.Category.IsDeleted && !cr.Recipe.IsDeleted);

        builder.Entity<ShoppingListRecipeIngredient>()
            .HasQueryFilter(slri => !slri.ShoppingList.IsDeleted && !slri.RecipeIngredient.IsDeleted);

        //add filter to recipes
        builder.Entity<Recipe>()
            .HasQueryFilter(r => r.IsAdminApproved == true);
        builder.Entity<Recipe>()
            .HasIndex(nameof(Recipe.IsAdminApproved))
            .HasFilter($"[{nameof(Recipe.IsAdminApproved)}] = 1");


        //adding soft delete flag
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

        //applying configurations to seed data
        builder.ApplyConfiguration(new AppUserConfiguration());
        builder.ApplyConfiguration(new RolesConfiguration());
        builder.ApplyConfiguration(new UsersRolesConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new IngredientConfiguration());
        builder.ApplyConfiguration(new CookingRankConfiguration());
        builder.ApplyConfiguration(new MeasurementUnitConfiguration());
        builder.ApplyConfiguration(new CookConfiguration());
        builder.ApplyConfiguration(new RecipeConfiguration());
        builder.ApplyConfiguration(new RecipeRatingConfiguration());
        builder.ApplyConfiguration(new RecipeImageConfiguration());
        builder.ApplyConfiguration(new RecipeIngredientConfiguration());
        builder.ApplyConfiguration(new UsersFavoriteRecipesConfiguration());
        builder.ApplyConfiguration(new CategoryRecipeConfiguration());
        builder.ApplyConfiguration(new CommentConfiguration());
        builder.ApplyConfiguration(new ReplyConfiguration());
        builder.ApplyConfiguration(new ShoppingListConfiguration());
        builder.ApplyConfiguration(new ShoppingListRecipeIngredientConfiguration());

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