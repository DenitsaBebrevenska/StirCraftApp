using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Infrastructure.Data.EntityConfigurations;
using System.Reflection;

namespace StirCraftApp.Infrastructure.Data;
public class StirCraftDbContext(DbContextOptions<StirCraftDbContext> options) : IdentityDbContext<AppUser>(options)
{
    #region DbSets
    public DbSet<AppUser> AppUsers { get; set; } = null!;
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

    public DbSet<UserFavoriteRecipe> UsersFavoriteRecipes { get; set; } = null!;

    public DbSet<CategoryRecipe> CategoriesRecipes { get; set; } = null!;

    #endregion
    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Joined tables config

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


        builder.Entity<UserFavoriteRecipe>()
            .HasKey(ufr => new { ufr.UserId, ufr.RecipeId });

        builder.Entity<UserFavoriteRecipe>()
            .HasOne(ufr => ufr.AppUser)
            .WithMany(u => u.FavoriteRecipes)
            .HasForeignKey(ufr => ufr.UserId);

        builder.Entity<UserFavoriteRecipe>()
            .HasOne(ufr => ufr.Recipe)
            .WithMany(r => r.UserFavoriteRecipes)
            .HasForeignKey(ufr => ufr.RecipeId);

        #endregion
        builder.Entity<AppUser>()
            .HasIndex(u => u.DisplayName)
            .IsUnique();

        #region delete behaviour no action for all FK and explicit filter for joined tables
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
            .HasQueryFilter(ufr => !ufr.Recipe.IsDeleted && !ufr.AppUser.IsDeleted);

        builder.Entity<CategoryRecipe>()
            .HasQueryFilter(cr => !cr.Category.IsDeleted && !cr.Recipe.IsDeleted);

        #endregion


        #region Soft delete filter
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

        #endregion

        #region Applying configuration that seed data
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

        #endregion
        base.OnModelCreating(builder);
    }

    /// <summary>
    /// Applies a global query filter to the entity type <typeparamref name="TEntity"/> 
    /// to exclude soft-deleted entities based on the "IsDeleted" property.
    /// This ensures that soft-deleted entities are automatically excluded from query results.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to which the filter will be applied.</typeparam>
    private static void ApplySoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : class
    {
        builder.Entity<TEntity>()
            .HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
    }

    /// <summary>
    /// Applies a filtered index on the "IsDeleted" property of the specified entity type.
    /// This helps optimize queries that filter on the "IsDeleted" field by making them more efficient.
    /// </summary>
    /// <param name="builder">The ModelBuilder used to configure the entity.</param>
    /// <param name="entityType">The type of the entity to which the index will be applied.</param>
    private static void ApplyFilteredIndex(ModelBuilder builder, Type entityType)
    {
        var entityBuilder = builder.Entity(entityType);

        entityBuilder.HasIndex(nameof(ISoftDeletable.IsDeleted))
            .HasFilter($"[{nameof(ISoftDeletable.IsDeleted)}] = 0");
    }

}