using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.JoinedTables;
using StirCraftApp.Infrastructure.Data.JoinedTables;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class CategoryRecipeConfiguration : IEntityTypeConfiguration<CategoryRecipe>
{
    public void Configure(EntityTypeBuilder<CategoryRecipe> builder)
    {
        var categoriesRecipes = JsonSeedHelper.LoadJsonData<CategoryRecipe>("CategoriesRecipes");

        builder.HasData(categoriesRecipes);
    }
}
