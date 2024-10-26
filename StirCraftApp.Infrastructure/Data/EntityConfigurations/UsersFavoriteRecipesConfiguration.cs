using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Infrastructure.Data.JoinedTables;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class UsersFavoriteRecipesConfiguration : IEntityTypeConfiguration<UserFavoriteRecipe>
{
    public void Configure(EntityTypeBuilder<UserFavoriteRecipe> builder)
    {
        var usersFavoriteRecipes = JsonSeedHelper.LoadJsonData<UserFavoriteRecipe>("UsersFavoriteRecipes");

        builder.HasData(usersFavoriteRecipes);
    }

}
