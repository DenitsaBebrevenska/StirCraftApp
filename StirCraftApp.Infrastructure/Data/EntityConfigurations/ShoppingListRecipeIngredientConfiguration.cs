using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Infrastructure.Data.JoinedTables;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class ShoppingListRecipeIngredientConfiguration : IEntityTypeConfiguration<ShoppingListRecipeIngredient>
{
    public void Configure(EntityTypeBuilder<ShoppingListRecipeIngredient> builder)
    {
        var listsIngredients = JsonSeedHelper
            .LoadJsonData<ShoppingListRecipeIngredient>("ShoppingListsRecipeIngredients");

        builder.HasData(listsIngredients);
    }
}
