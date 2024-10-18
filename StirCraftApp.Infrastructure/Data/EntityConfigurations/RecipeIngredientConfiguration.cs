using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Data.SeedData;

namespace StirCraftApp.Infrastructure.Data.EntityConfigurations;
public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
	public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
	{
		var recipeIngredients = JsonSeedHelper.LoadJsonData<RecipeIngredient>("RecipeIngredients");

		builder.HasData(recipeIngredients);
	}
}
